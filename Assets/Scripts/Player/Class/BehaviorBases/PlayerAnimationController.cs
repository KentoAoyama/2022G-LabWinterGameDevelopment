using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerAnimationController
{
    // アニメーションパラメーター名共通
    /// <summary> アニメーションスピード制御用パラメーター名 </summary>
    protected const string AnimSpeedParamName = "";
    /// <summary> アイドル時のアニメーションパラメーター名 </summary>
    protected const string IdleParamName = "";
    /// <summary> 移動時のアニメーションパラメーター名 </summary>
    protected const string MoveParamName = "";
    /// <summary> 上昇時のアニメーションパラメーター名 </summary>
    protected const string RiseParamName = "";
    /// <summary> 落下時のアニメーションパラメーター名 </summary>
    protected const string FallParamName = "";
    /// <summary> 攻撃時のアニメーションパラメーター名 </summary>
    protected const string AttackParamName = "";
    /// <summary> ギミック操作時のアニメーションパラメーター名 </summary>
    protected const string ActionParamName = "";
    /// <summary> ダメージ時のアニメーションパラメーター名 </summary>
    protected const string DamageParamName = "";

    protected Animator _animator = default;
    protected PlayerStateController _stateController = default;
    /// <summary> アイドル時のアニメーションパラメーター </summary>
    protected bool _isIdle = false;
    /// <summary> 移動時のアニメーションパラメーター </summary>
    protected bool _isMove = false;
    /// <summary> 上昇時のアニメーションパラメーター </summary>
    protected bool _isRise = false;
    /// <summary> 落下時のアニメーションパラメーター </summary>
    protected bool _isFall = false;
    /// <summary> 攻撃時のアニメーションパラメーター </summary>
    protected bool _isAttack = false;
    /// <summary> ギミック操作時のアニメーションパラメーター </summary>
    protected bool _isAction = false;
    /// <summary> ダメージ時のアニメーションパラメーター </summary>
    protected bool _isDamage = false;

    public void Init(Animator animator,
        PlayerStateController stateController)
    {
        _animator = animator;
        _stateController = stateController;
    }

    public void Updata()
    {
        InitValue();
        UpdateValue();
        SetValue();
    }

    protected virtual void InitValue()
    {
        _isIdle = false;
        _isMove = false;
        _isRise = false;
        _isFall = false;
        _isAttack = false;
        _isAction = false;
        _isDamage = false;
    }
    protected abstract void UpdateValue();
    protected virtual void SetValue()
    {
        _animator.SetBool(IdleParamName,_isIdle);
        _animator.SetBool(MoveParamName,_isMove);
        _animator.SetBool(RiseParamName,_isRise);
        _animator.SetBool(FallParamName,_isFall);
        _animator.SetBool(AttackParamName,_isAttack);
        _animator.SetBool(ActionParamName,_isAction);
        _animator.SetBool(DamageParamName,_isDamage);
    }
}