using System;
using UnityEngine;

[System.Serializable]
public class PlayerAnimationController3D : PlayerAnimationController
{
    // �A�j���[�V�����p�����[�^�[��2D�p
    /// <summary> �W�����v���̃A�j���[�V�����p�����[�^�[�� </summary>
    private const string StepParamName = "";
    /// <summary> �W�����v���̃A�j���[�V�����p�����[�^�[ </summary>
    private bool _isStep = false;

    protected override void InitValue()
    {
        base.InitValue();
        _isStep = false;
    }
    protected override void UpdateValue()
    {
        switch (_stateController.NowState)
        {
            case PlayerState.IDLE:
                _isIdle = true;
                break;
            case PlayerState.MOVE:
                _isMove = true;
                break;
            case PlayerState.DAMAGE:
                _isDamage = true;
                break;
            case PlayerState.ACTION:
                _isAction = true;
                break;
            case PlayerState.RISE:
                _isRise = true;
                break;
            case PlayerState.FALL:
                _isFall = true;
                break;
            case PlayerState.ATTACK:
                _isAttack = true;
                break;
            case PlayerState.STEP_3D:
                _isStep = true;
                break;
            default:
                Debug.LogError("�s���Ȓl�ł��I�C�����Ă��������I");
                break;
        }
    }
    protected override void SetValue()
    {
        base.SetValue();
        _animator.SetBool(StepParamName, _isStep);
    }
}