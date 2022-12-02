using UnityEngine;
using System.Threading.Tasks;

[System.Serializable]
public class EnemyShortAttack2D : EnemyAttackBase
{
    [SerializeField, Tooltip("攻撃のインターバル(2D)")]
    private int _attackInterval = 3;
    [SerializeField, Tooltip("攻撃スピード")]
    private float _attackSpeed = 6f;

    private EnemyMove2D _enemyMove2D;
    private Rigidbody2D _rb2D;

    public void AttackSet(EnemyMove2D enemyMove2D, Rigidbody2D rb2D)
    {
        _enemyMove2D = enemyMove2D;
        _rb2D = rb2D;
    }

    public override void EnemyAttack()
    {
        if (_enemyMove2D.PlayerSearch(_enemyMove2D.AttackDistance) && !_isAttack)
        {
            AttackDirection();
            Task.Run(() => EnemyAttackInterval(_attackInterval));
        }
    }

    /// <summary>
    /// 攻撃の方向の識別
    /// </summary>
    private void AttackDirection()
    {
        if (_enemyMove2D.EnemyDistans < 0)
        {
            _rb2D.AddForce(-Vector3.right * _attackSpeed, ForceMode2D.Impulse);
        }
        else
        {
            _rb2D.AddForce(Vector3.right * _attackSpeed, ForceMode2D.Impulse);
        }
    }
}
