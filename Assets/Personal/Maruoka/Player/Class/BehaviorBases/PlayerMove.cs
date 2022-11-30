using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerMove
{
    [SerializeField]
    private bool _isMove = true;

    public bool IsKnockBackNow { get; set; }

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
        if (IsKnockBackNow) { } // �m�b�N�o�b�N���́AVelocity�̏㏑���͍s��Ȃ��B�i���������ɔC����j
        else if (IsRun())
        {
            Move();
        }
        else
        {
            StopMove();
        }
        StateUpdate();
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
    protected abstract void StopMove();
    protected abstract void StateUpdate();
}