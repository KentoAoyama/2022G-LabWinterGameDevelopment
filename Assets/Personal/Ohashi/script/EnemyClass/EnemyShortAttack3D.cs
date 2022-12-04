using UnityEngine;
using System.Threading.Tasks;

[System.Serializable]
public class EnemyShortAttack3D : EnemyAttackBase
{
    [SerializeField, Tooltip("�U���̃C���^�[�o��(3D)")]
    private int _attackInterval = 3;
    [SerializeField, Tooltip("�U���̃X�s�[�h")]
    private float _attackSpeed = 6f;

    private EnemyMove3D _enemyMove3D;
    private Rigidbody _rb;

    public void Init(EnemyMove3D enemyMove3D, Rigidbody rb,
        EnemyStateController stateController)
    {
        _enemyMove3D = enemyMove3D;
        _rb = rb;
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
        if (_enemyMove3D.EnemyDistance < 0)
        {
            _rb.AddForce(-Vector3.right * _attackSpeed, ForceMode.Impulse);
        }
        else
        {
            _rb.AddForce(Vector3.right * _attackSpeed, ForceMode.Impulse);
        }
    }
}
