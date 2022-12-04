using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController3D : RetainedEnemyBehavior, IAddDamage, IPause
{
    [SerializeField, Tooltip("移動")]
    private EnemyMove3D _enemyMove = new();
    [SerializeField, Tooltip("近距離攻撃")]
    private EnemyShortAttack3D _enemyShortAttack3D = new();
    [SerializeField, Tooltip("遠距離攻撃")]
    private EnemyLongAttack _enemyLongAttack = new();
    [SerializeField, Tooltip("ヒットポイントを管理しているクラス")]
    private EnemyHealth _enemyHealth = new();
    [SerializeField, Tooltip("状態管理")]
    private EnemyStateController _stateController = new();
    [SerializeField, Tooltip("エネミーのタイプ")]
    private EnemyId _enemyId;
    [SerializeField, Tooltip("ポーズ中かどうか")]
    private bool _isPause = false;

    private Rigidbody _rb;
    private int _id;

    public EnemyMove3D EnemyMove => _enemyMove;
    public override int Id => _id;

    public override int Health { get => _enemyHealth.Health; set => _enemyHealth.Health = value; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _stateController.InIt(EnemyMove, _enemyLongAttack, _enemyHealth,
            _enemyShortAttack3D, _enemyId);
        _enemyHealth.InIt(gameObject, _stateController);
        _enemyMove.InIt(_rb, transform,
            ObjectHolderManager.Instance.PlayerHolder, _stateController);
        _enemyShortAttack3D.InIt(_enemyMove, _rb, _stateController);
        _id = (int)_enemyId;
    }

    private void Update()
    {
        if(!_isPause)
        {
            _stateController.State();
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
        else if(_stateController.EnemyState == EnemyState.LongAttack)
        {
            _enemyLongAttack.EnemyAttack();
            _enemyLongAttack.Bullet.GetComponent<EnemyBulletController3D>().Set(_enemyMove);
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
            Debug.Log("攻撃が当たった");
        }
    }
}
