using System;
using UnityEngine;

[System.Serializable]
public class PlayerAnimationController2D : PlayerAnimationController
{
    // アニメーションパラメーター名2D用
    /// <summary> ジャンプ時のアニメーションパラメーター名 </summary>
    private const string JumpParamName = "IsJump";
    /// <summary> ジャンプ時のアニメーションパラメーター名 </summary>
    private bool _isJump = false;

    protected override void InitValue()
    {
        base.InitValue();
        _isJump = false;
    }
    protected override void UpdateValue()
    {
        switch (_stateController.CurrentState)
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
            case PlayerState.JUMP_2D:
                _isJump = true;
                break;
            default:
                Debug.LogError("不正な値です！修正してください！");
                break;
        }
    }
    protected override void SetValue()
    {
        base.SetValue();
        _animator.SetBool(JumpParamName, _isJump);
    }
}