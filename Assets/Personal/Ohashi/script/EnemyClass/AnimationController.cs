using UnityEngine;
/// <summary>
/// �G�l�~�[�̃A�j���[�V�����Ǘ��N���X
/// </summary>
[System.Serializable]
public class AnimationController
{
    private EnemyStateController _stateController;
    private Animator _anim;

    public void Init(EnemyStateController stateController, Animator anim)
    {
        _stateController = stateController;
        _anim = anim;
    }
    /// <summary>
    /// �G�l�~�[�A�j���[�V�����̊Ǘ�
    /// </summary>
    public void Animation()
    {
        FindAnimation();
        MoveAnimation();
        LongAttackAnimation();
        ShotAttackAnimation();
        DamageAnimation();
    }

    /// <summary>
    /// �ړ��̃A�j���[�V�����Ǘ�
    /// </summary>
    private void MoveAnimation()
    {
        _anim.SetBool("IsMove",
            _stateController.EnemyState == EnemyState.Move ? true : false);
    }

    /// <summary>
    /// �������U���̃A�j���[�V�����Ǘ�
    /// </summary>
    private void LongAttackAnimation()
    {
        _anim.SetBool("IsLongAttack",
            _stateController.EnemyState == EnemyState.LongAttack ? true : false);
    }

    /// <summary>
    /// �ߋ����U���̃A�j���[�V�����Ǘ�
    /// </summary>
    private void ShotAttackAnimation()
    {
        _anim.SetBool("IsShotAttack",
            _stateController.EnemyState == EnemyState.ShotAttack ? true : false);
    }

    /// <summary>
    /// �����A�j���[�V�����̊Ǘ�
    /// </summary>
    private void FindAnimation()
    {
        _anim.SetBool("IsFind",
            _stateController.EnemyState == EnemyState.Find ? true : false);
    }

    /// <summary>
    /// �_���[�W�A�j���[�V�����̊Ǘ�
    /// </summary>
    private void DamageAnimation()
    {
        if (_stateController.EnemyState == EnemyState.Damage)
        {
            _anim.Play("Damage");
        }
    }
}
