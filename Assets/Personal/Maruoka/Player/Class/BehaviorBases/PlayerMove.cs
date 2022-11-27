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
                // Debug.Log("�v���C���[���ړ��\�ɂ��܂�");
            }
            else
            {
                // Debug.LogWarning("�v���C���[���ړ��s�ɂ��܂�");
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
        // �璷�Ȃ̂ł����C������B
        return _isMove =
            _nowState == PlayerState.IDLE ||
            _nowState == PlayerState.MOVE ||
            _nowState == PlayerState.JUMP_2D ||
            _nowState == PlayerState.FALL ||
            _nowState == PlayerState.RISE;
    }

    protected abstract void Move();
}