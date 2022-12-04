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

    public void InIt(EnemyMove2D enemyMove2D, Rigidbody2D rb2D,
        EnemyStateController stateController)
    {
        _enemyMove2D = enemyMove2D;
        _rb2D = rb2D;
        _stateController = stateController;
    }

    public override void EnemyAttack()
    {
        AttackDirection();
        Task.Run(() => EnemyAttackInterval(_attackInterval));
    }

    /// <summary>
    /// �U���̕����̎���
    /// </summary>
    private void AttackDirection()
    {
        if (_enemyMove2D.EnemyDistance < 0)
        {
            _rb2D.AddForce(-Vector3.right * _attackSpeed, ForceMode2D.Impulse);
        }
        else
        {
            _rb2D.AddForce(Vector3.right * _attackSpeed, ForceMode2D.Impulse);
        }
    }
}
