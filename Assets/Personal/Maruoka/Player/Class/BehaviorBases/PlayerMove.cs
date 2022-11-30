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
                // Debug.Log("プレイヤーを移動可能にします");
            }
            else
            {
                // Debug.LogWarning("プレイヤーを移動不可にします");
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
        if (IsKnockBackNow) { } // ノックバック中は、Velocityの上書きは行わない。（物理挙動に任せる）
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