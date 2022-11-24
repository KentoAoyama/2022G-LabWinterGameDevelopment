using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerMove
{
    [SerializeField]
    private bool _isMove = true;

    public bool IsMove
    {
        get => _isMove;
        set
        {
            if (value)
            {
                // Debug.Log("プレイヤーを移動可能にします");
            }
            else
            {
                // Debug.LogWarning("プレイヤーを移動不可にします");
            }
            _isMove = value;
        }
    }

    public virtual void Update(PlayerState _nowState)
    {
        if (IsRun(_nowState))
        {
            Move();
        }
    }

    protected bool IsRun(PlayerState _nowState)
    {
        // 冗長なのでいつか修正する。
        return _isMove =
            _nowState == PlayerState.IDLE ||
            _nowState == PlayerState.MOVE ||
            _nowState == PlayerState.JUMP_2D ||
            _nowState == PlayerState.FALL ||
            _nowState == PlayerState.RISE;
    }

    protected abstract void Move();
}