using UnityEngine;

[System.Serializable]
public class EnemyStateController
{
    [SerializeField]
    private EnemyState _enemyState;

    private EnemyAttackBase _enemyLongAttack;
    private EnemyAttackBase _enemyShotAttack;
    private EnemyHealth _enemyHealth;
    private EnemyMove _enemyMove;
    private EnemyId _enemyId;

    public EnemyState EnemyState => _enemyState;

    public void InIt(EnemyMove enemyMove, EnemyAttackBase enemyLongAttack,
        EnemyHealth enemyHealth, EnemyAttackBase enemyShotAttack, EnemyId enemyId)
    {
        _enemyMove = enemyMove;
       _enemyLongAttack = enemyLongAttack;
        _enemyHealth = enemyHealth;
        _enemyShotAttack = enemyShotAttack;
        _enemyId = enemyId;
    }
    public void State()
    {
        _enemyState = EnemyState.Idle;
        Move();
        Attack();
        LongAttack();
        Death();
    }

    private void Move()
    {
        if (_enemyMove.PlayerSearch(_enemyMove.MoveDistansce) &&
            !_enemyMove.PlayerSearch(_enemyMove.AttackDistance))
        {
            _enemyState = EnemyState.Move;
        }
    }
    private void Attack()
    {
        if (_enemyId == EnemyId.Short && _enemyMove.PlayerSearch(_enemyMove.AttackDistance)
            && !_enemyShotAttack.IsAttack)
        {
            _enemyState = EnemyState.ShotAttack;
        }
    }
    private void LongAttack()
    {
        if (_enemyId == EnemyId.Long && _enemyMove.PlayerSearch(_enemyMove.AttackDistance)
            && !_enemyLongAttack.IsAttack)
        {
            Debug.Log("2");
            _enemyState = EnemyState.LongAttack;
        }
    }
    private void Damage()
    {

    }
    private void Death()
    {
        if (_enemyHealth.Health <= 0)
        {
            _enemyState = EnemyState.Death;
        }
    }
}
