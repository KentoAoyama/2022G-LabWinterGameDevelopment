using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController2D : RetainedEnemyBehavior, IAddDamage, IPause
{
    [SerializeField, Tooltip("移動")]
    private EnemyMove2D _enemyMove;
    [SerializeField, Tooltip("近距離攻撃")]
    private EnemyShortAttack2D _enemyShortAttack2D;
    [SerializeField, Tooltip("遠距離攻撃")]
    private EnemyLongAttack _enemyLongAttack;
    [SerializeField, Tooltip("ヒットポイントを管理しているクラス")]
    private EnemyHealth _enemyHealth;
    [SerializeField, Tooltip("状態管理")]
    private EnemyStateController _stateController;
    [SerializeField, Tooltip("アニメーション管理")]
    AnimationController _animationController;
    [SerializeField]
    AnimationEventController _animationEventController;
    [SerializeField, Tooltip("エネミーのタイプ")]
    private EnemyId _enemyId;
    [SerializeField, Tooltip("ポーズ中かどうか")]
    private bool _isPause = false;
    [SerializeField]
    Animator _anim;

    private Rigidbody2D _rb2D;
    private int _id;

    public override int Id => _id;

    public override int Health { get => _enemyHealth.Health; set => _enemyHealth.Health = value; }

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _stateController.Init(_enemyMove, _enemyLongAttack, _enemyHealth,
            _enemyShortAttack2D, _enemyId);
        _enemyHealth.Init(gameObject, _stateController);
        _enemyMove.InIt(_rb2D, transform,
            ObjectHolderManager.Instance.PlayerHolder, _stateController);
        _enemyShortAttack2D.InIt(_enemyMove, _rb2D, _stateController);
        _animationController.Init(_stateController, _anim);
        _animationEventController.Init(_enemyMove, _enemyLongAttack);
        _id = (int)_enemyId;
        _enemyMove.Test();
    }

    private void Update()
    {
        if(!_isPause)
        {
            _stateController.State();
            _animationController.Animation();
            _enemyMove.Move();
            Attack();
        }
    }

    /// <summary>
    /// タイプ別で攻撃を識別
    /// </summary>
    private void Attack()
    {
        if (_stateController.EnemyState == EnemyState.ShotAttack)
        {
            _enemyShortAttack2D.EnemyAttack();
        }
        else if(_stateController.EnemyState == EnemyState.LongAttack)
        {
            _enemyLongAttack.EnemyAttack();
            _enemyLongAttack.Bullet.GetComponent<EnemyBulletController2D>().Init(_enemyMove);
        }
    }

    void IAddDamage.AddDamage(int damage)
    {
        _enemyHealth.EnemyDamage(damage);
    }

    public void Pause()
    {
        _isPause = true;
    }

    public void Resume()
    {
        _isPause = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //IAddDamageを継承しているクラスのオブジェクトに接触したとき以下を実行する
        if (collision.TryGetComponent(out IAddDamage addDamage))
        {
            Debug.Log("攻撃が当たった");
        }
    }
}
