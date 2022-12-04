using UnityEngine;

[System.Serializable]
public class EnemyStateController3D
{
    [SerializeField]
    private EnemyState _enemyState;

    private EnemyMove3D _enemyMove3D;
    private EnemyAttackBase _enemyAttack;
    private EnemyHealth _enemyHealth;

    public EnemyState EnemyState => _enemyState;

    public void InIt(EnemyMove3D enemyMove3D, EnemyAttackBase enemyAttack, EnemyHealth enemyHealth)
    {
        _enemyMove3D = enemyMove3D;
        _enemyAttack = enemyAttack;
        _enemyHealth = enemyHealth;
    }

    public void State()
    {
        Idle();
        Move();
        Attack();
        Death();
    }

    private void Idle()
    {
        if(!_enemyAttack.IsAttack)
        {
            _enemyState = EnemyState.Idle;
        }
    }
    private void Move()
    {
        if(_enemyMove3D.PlayerSearch(_enemyMove3D.MoveDistansce) && 
            !_enemyMove3D.PlayerSearch(_enemyMove3D.AttackDistance))
        {
            _enemyState = EnemyState.Move;
        }
    }
    private void Attack()
    {
        if(_enemyMove3D.PlayerSearch(_enemyMove3D.AttackDistance) && !_enemyAttack.IsAttack)
        {
            _enemyState = EnemyState.Attack;
        }
    }
    private void Damage()
    {

    }
    private void Death()
    {
        if(_enemyHealth.Health <= 0)
        {
            _enemyState = EnemyState.Death;
        }
    }
}
