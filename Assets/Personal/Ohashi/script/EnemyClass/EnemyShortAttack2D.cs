using UnityEngine;
using System.Threading.Tasks;

[System.Serializable]
public class EnemyShortAttack2D : EnemyAttackBase
{
    [SerializeField, Tooltip("�U���̃C���^�[�o��(2D)")]
    private int _attackInterval = 3;
    [SerializeField, Tooltip("�U���X�s�[�h")]
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
    /// �U���̕����̎���
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
