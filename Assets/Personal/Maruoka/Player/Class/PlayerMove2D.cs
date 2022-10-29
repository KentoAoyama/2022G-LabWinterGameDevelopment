using System;
using UnityEngine;

[System.Serializable]
public class PlayerMove2D : PlayerMove
{
    private readonly SelfMadeInput _inputer = new Input_InputManager();
    private readonly GroundCheck _groundChecker = default;
    private readonly string _horizontalButtonName = "";
    private readonly string _jumpButtonName = "";

    private Rigidbody2D _rb2D = default;
    private float _moveSpeed = default;
    private float _jumpPower = default;

    public PlayerMove2D(Component rb2D, float moveSpeed, float jumpPower,
        string horizontalButtonName, string jumpButtonName, GroundCheck groundCheck)
    {
        Init(rb2D);
        _moveSpeed = moveSpeed;
        _jumpPower = jumpPower;
        _horizontalButtonName = horizontalButtonName;
        _jumpButtonName = jumpButtonName;
        _groundChecker = groundCheck;
    }

    protected override void Init(Component rb2D)
    {
        if (rb2D is Rigidbody2D)
        {
            _rb2D = rb2D as Rigidbody2D;
        }
#if UNITY_EDITOR
        else if (rb2D == null)
        {
            Debug.LogError("引数\"rb2D\"がnullです！");
        }
        else
        {
            Debug.LogError("引数\"rb2D\"が不正です！");
        }
#endif
    }

    public override void Move()
    {
        // 水平移動
        _rb2D.velocity =
            new Vector2(
                _moveSpeed * _inputer.GetAxisRaw(_horizontalButtonName),
                _rb2D.velocity.y);
        // ジャンプ
        if (_inputer.GetInputDown(_jumpButtonName) && _groundChecker.IsGround())
        {
            _rb2D.velocity = new Vector2(0f, _jumpPower);
        }
    }
}