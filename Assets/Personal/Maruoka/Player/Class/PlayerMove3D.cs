using System;
using UnityEngine;

[System.Serializable]
public class PlayerMove3D : PlayerMove
{
    [InputName, SerializeField]
    private string _horizontalButtonName = default;
    [SerializeField]
    private float _moveSpeed;

    private Rigidbody _rb = default;
    private RailControl3D _railControler = default;

    public bool IsStepNow => _railControler.IsStepNow;

    public void Init(Rigidbody rb, Transform transform,
        RailControl3D railControler, PlayerStateController stateController)
    {
        base.Init(stateController);
        _rb = rb;
        _railControler = railControler;
        _stateController = stateController;
        _railControler.Init(transform, stateController);
    }

    protected override void Move()
    {
        // êÖïΩà⁄ìÆ
        _rb.velocity =
            new Vector3(
                _moveSpeed * Input_InputManager.Instance.GetAxisRaw(_horizontalButtonName),
                _rb.velocity.y,
                0.0f
                );
    }
    protected override void StopMove()
    {
        _rb.velocity = new Vector3(0.0f, _rb.velocity.y, 0.0f);
    }
    public override void Update()
    {
        if (IsRun())
        {
            Move();
            _railControler.Update();
        }
        else
        {
            StopMove();
        }
        StateUpdate();
    }

    protected override void StateUpdate()
    {
        if (!Mathf.Approximately(_rb.velocity.x, 0f))
        {
            _stateController.CurrentState = PlayerState.MOVE;
        }
        if (_railControler.IsStepNow)
        {
            _stateController.CurrentState = PlayerState.STEP_3D;
        }
    }
}