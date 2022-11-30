using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController3D : RetainedEnemyBehavior, IAddDamage, IPause
{
    [SerializeField, Tooltip("移動")]
    private EnemyMove3D _enemyMove = new EnemyMove3D();
    [SerializeField, Tooltip("近距離攻撃")]
    private EnemyShortAttack3D _enemyShortAttack3D = new EnemyShortAttack3D();
    [SerializeField, Tooltip("遠距離攻撃")]
    private EnemyLongAttack _enemyLongAttack = new EnemyLongAttack();
    [SerializeField, Tooltip("ヒットポイントを管理しているクラス")]
    private EnemyHealth _enemyHealth = new EnemyHealth();
    [SerializeField, Tooltip("エネミーのタイプ")]
    private EnemyId _enemyId;

    private Rigidbody _rb;
    private int _id;
    private bool _isPause = false;

    public EnemyMove3D EnemyMove => _enemyMove;
    protected override int Id => _id;

    protected override int Health { get => _enemyHealth.Health; set => _enemyHealth.Health = value; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _enemyMove.SetBase(transform, ObjectHolderManager.Instance.PlayerHolder);
        _enemyMove.Set3D(_rb);
        _enemyShortAttack3D.AttackSet(_enemyMove, _rb);
        _enemyLongAttack.LongAttackSet(_enemyMove);
        _id = (int)_enemyId;
    }

    private void Update()
    {
        if(!_isPause)
        {
            _enemyMove.Move();
            Attack();
        }
    }

    /// <summary>
    /// タイプ別で攻撃を識別
    /// </summary>
    private void Attack()
    {
        if(_enemyId == EnemyId.Short)
        {
            _enemyShortAttack3D.EnemyAttack();
        }
        else
        {
            _enemyLongAttack.EnemyAttack();
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
