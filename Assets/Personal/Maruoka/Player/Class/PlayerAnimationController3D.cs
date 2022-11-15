using System;
using UnityEngine;

[System.Serializable]
public class PlayerAnimationController3D : PlayerAnimationController
{
    // アニメーションパラメーター名2D用
    /// <summary> ジャンプ時のアニメーションパラメーター名 </summary>
    private const string StepParamName = "";
    /// <summary> ジャンプ時のアニメーションパラメーター </summary>
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
                Debug.LogError("不正な値です！修正してください！");
                break;
        }
    }
    protected override void SetValue()
    {
        base.SetValue();
        _animator.SetBool(StepParamName, _isStep);
    }
}