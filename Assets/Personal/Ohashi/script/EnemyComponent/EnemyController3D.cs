using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController3D : RetainedEnemyBehavior, IAddDamage, IPause
{
    [SerializeField, Tooltip("移動")]
    private EnemyMove3D _enemyMove;
    [SerializeField, Tooltip("近距離攻撃")]
    private EnemyShortAttack3D _enemyShortAttack3D;
    [SerializeField, Tooltip("遠距離攻撃")]
    private EnemyLongAttack _enemyLongAttack;
    [SerializeField, Tooltip("ヒットポイントを管理しているクラス")]
    private EnemyHealth _enemyHealth;
    [SerializeField, Tooltip("状態管理")]
    private EnemyStateController _stateController;
    [SerializeField, Tooltip("エネミーのタイプ")]
    private EnemyId _enemyId;
    [SerializeField, Tooltip("アニメーション管理")]
    AnimationController _animationController;
    [SerializeField]
    AnimationEventController _animationEventController;
    [SerializeField, Tooltip("ポーズ中かどうか")]
    private bool _isPause = false;
    [SerializeField]
    private Animator _anim;

    private Rigidbody _rb;
    private int _id;

    public EnemyMove3D EnemyMove => _enemyMove;
    public override int Id => _id;

    public override int Health { get => _enemyHealth.Health; set => _enemyHealth.Health = value; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _stateController.Init(EnemyMove, _enemyLongAttack, _enemyHealth,
            _enemyShortAttack3D, _enemyId);
        _enemyHealth.Init(gameObject, _stateController);
        _enemyMove.InIt(_rb, transform,
            ObjectHolderManager.Instance.PlayerHolder, _stateController);
        _enemyShortAttack3D.InIt(_enemyMove, _rb, _stateController);
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
        if(_stateController.EnemyState == EnemyState.ShotAttack)
        {
            _enemyShortAttack3D.EnemyAttack();
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

    private void OnTriggerEnter(Collider other)
    {
        //IAddDamageを継承しているクラスのオブジェクトに接触したとき以下を実行する
        if (other.TryGetComponent(out IAddDamage addDamage))
        {
            addDamage.AddDamage(_enemyShortAttack3D.AttackPower);
            Debug.Log("攻撃が当たった");
        }
    }
}
