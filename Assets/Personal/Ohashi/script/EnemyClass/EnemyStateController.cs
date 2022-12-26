using UnityEngine;

/// <summary>
/// ステートを管理するクラス
/// </summary>
[System.Serializable]
public class EnemyStateController
{
    [SerializeField, Tooltip("エネミーステート")]
    private EnemyState _enemyState;

    private EnemyAttackBase _enemyLongAttack;
    private EnemyAttackBase _enemyShotAttack;
    private EnemyHealth _enemyHealth;
    private EnemyMove _enemyMove;
    private EnemyId _enemyId;

    public EnemyState EnemyState => _enemyState;

    public void Init(EnemyMove enemyMove, EnemyAttackBase enemyLongAttack,
        EnemyHealth enemyHealth, EnemyAttackBase enemyShotAttack,
        EnemyId enemyId)
    {
        _enemyMove = enemyMove;
       _enemyLongAttack = enemyLongAttack;
        _enemyHealth = enemyHealth;
        _enemyShotAttack = enemyShotAttack;
        _enemyId = enemyId;
    }
    /// <summary>
    /// ステート管理
    /// </summary>
    public void State()
    {
        _enemyState = EnemyState.Idle;
        Move();
        Damage();
        Find();
        
        Attack();
        LongAttack();
        Death();
    }

    /// <summary>
    /// 移動のステート管理
    /// </summary>
    private void Move()
    {
        if (_enemyMove.PlayerSearch(_enemyMove.MoveDistansce) &&
            !_enemyMove.PlayerSearch(_enemyMove.AttackDistance))
        {
            _enemyState = EnemyState.Move;
        }
    }

    /// <summary>
    /// 近距離攻撃のステート管理
    /// </summary>
    private void Attack()
    {
        if (_enemyId == EnemyId.Short && _enemyMove.PlayerSearch(_enemyMove.AttackDistance)
            && !_enemyShotAttack.IsAttack)
        {
            _enemyState = EnemyState.ShotAttack;
        }
    }

    /// <summary>
    /// 遠距離攻撃のステート管理
    /// </summary>
    private void LongAttack()
    {
        if (_enemyId == EnemyId.Long && _enemyMove.PlayerSearch(_enemyMove.AttackDistance)
            && !_enemyLongAttack.IsAttack)
        {
            _enemyState = EnemyState.LongAttack;
        }
    }

    /// <summary>
    /// 発見時のステート管理
    /// </summary>
    private void Find()
    {
        if(_enemyMove.IsFinding)
        {
            _enemyState = EnemyState.Find;
            _enemyMove.IsFinding = false;
        }
    }

    /// <summary>
    /// ダメージのステートを管理
    /// </summary>
    private void Damage()
    {
        if(_enemyHealth.IsDamage)
        {
            Debug.Log("ddd");
            _enemyState = EnemyState.Damage;
            _enemyHealth.IsDamage = false;
        }
    }

    /// <summary>
    /// ヒットポイントが0になったときのステートを管理
    /// </summary>
    private void Death()
    {
        if (_enemyHealth.Health <= 0)
        {
            _enemyState = EnemyState.Death;
        }
    }
}
