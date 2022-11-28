using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerMove
{
    [SerializeField]
    private bool _isMove = true;

    protected PlayerStateController _stateController = null;

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

    protected void Init(PlayerStateController stateController)
    {
        _stateController = stateController;
    }
    public virtual void Update()
    {
        if (IsRun())
        {
            Move();
        }
    }

    protected bool IsRun()
    {
        return _isMove =
            _stateController.CurrentState == PlayerState.IDLE ||
            _stateController.CurrentState == PlayerState.MOVE ||
            _stateController.CurrentState == PlayerState.JUMP_2D ||
            _stateController.CurrentState == PlayerState.FALL ||
            _stateController.CurrentState == PlayerState.RISE;
    }

    protected abstract void Move();
}