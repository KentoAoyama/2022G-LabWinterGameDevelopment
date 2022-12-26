using UnityEngine;
/// <summary>
/// �G�l�~�[�̃A�j���[�V�����C�x���g�̃N���X
/// </summary>
[RequireComponent(typeof(Animator))]
public class AnimationEventController : MonoBehaviour
{
    private EnemyMove _enemyMove;
    private EnemyLongAttack _enemyLongAttack;
    private EnemyAttackBase _enemyShotAttack;

    public void Init(EnemyMove enemyMove, EnemyLongAttack enemyLongAttack,
        EnemyAttackBase enemyShotAttack)
    {
        _enemyMove = enemyMove;
        _enemyLongAttack = enemyLongAttack;
        _enemyShotAttack = enemyShotAttack;
    }
    /// <summary>
    /// �������U���̃A�j���[�V�����C�x���g3D
    /// </summary>
    private void OnLongAttackEvent()
    {
        _enemyLongAttack.EnemyAttack();
    }
    /// <summary>
    /// �������U���̃A�j���[�V�����C�x���g2D
    /// </summary>
    private void OnLongAttackEvent2D()
    {
        _enemyLongAttack.EnemyAttack();
    }
    //�ߋ����U���̃A�j���[�V�����C�x���g
    private void OnShotAttackEvent()
    {
        _enemyShotAttack.EnemyAttack();
    }
}
