using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController2D : RetainedEnemyBehavior, IAddDamage
{
    [SerializeField]
    private EnemyMove2D _enemyMove = new EnemyMove2D();
    [SerializeField]
    private EnemyShortAttack2D _enemyShortAttack2D = new EnemyShortAttack2D();
    [SerializeField]
    private EnemyLongAttack _enemyLongAttack = new EnemyLongAttack();
    [SerializeField]
    private EnemyHealth _enemyHealth = new EnemyHealth();
    [SerializeField]
    private EnemyId _enemyId;


    private ObjectHolderManager _objectHolderManager;
    private Rigidbody2D _rb2D;
    private int _id;

    protected override int Id => _id;

    protected override int Health { get => _enemyHealth.Health; set => _enemyHealth.Health = value; }

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _objectHolderManager = ObjectHolderManager.Instance;
        _enemyMove.SetBase(transform, _objectHolderManager.PlayerHolder);
        _enemyMove.Set2D(_rb2D);
        _enemyShortAttack2D.AttackSet(_enemyMove, _rb2D);
        _enemyLongAttack.LongAttackSet(_enemyMove);
        _id = (int)_enemyId;
    }

    private void Update()
    {
        _enemyMove.Move();
        Attack();
    }

    /// <summary>
    /// タイプ別で攻撃を識別
    /// </summary>
    private void Attack()
    {
        if (_enemyId == EnemyId.Short)
        {
            _enemyShortAttack2D.EnemyAttack();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //IAddDamageを継承しているクラスのオブジェクトに接触したとき以下を実行する
        if (collision.TryGetComponent(out IAddDamage addDamage))
        {
            Debug.Log("攻撃が当たった");
        }
    }
}
