using UnityEngine;
using System.Threading.Tasks;

public abstract class EnemyAttackBase
{
    private const int MilliSecond = 1000;
    protected bool _isAttack = false;

    public bool IsAttack => _isAttack;

    /// <summary>
    /// �G�l�~�[�̍U������
    /// </summary>
    public abstract void EnemyAttack();
    /// <summary>
    /// �G�l�~�[�̍U���̃C���^�[�o��
    /// </summary>
    protected async Task EnemyAttackInterval(int attackInterval)
    {
        _isAttack = true;
        Debug.Log("attack");
        //�w�肵���~���b��Ɏ��s����
        await Task.Delay(MilliSecond * attackInterval);
        _isAttack = false;
    }
}
