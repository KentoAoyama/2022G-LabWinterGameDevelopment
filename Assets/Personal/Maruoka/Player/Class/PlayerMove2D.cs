using System;
using UnityEngine;

[System.Serializable]
public class PlayerMove2D : PlayerMove
{
    public bool IsJump => _isJump;

    [InputName, SerializeField]
    private string _horizontalButtonName = default;
    [InputName, SerializeField]
    private string _jumpButtonName = default;
    [SerializeField]
    private float _moveSpeed = default;
    [SerializeField]
    private float _jumpPower = default;

    private GroundCheck _groundChecker = default;
    private Rigidbody2D _rb2D = default;
    private bool _isJump = false;


    public void Init(Rigidbody2D rb2D, GroundCheck groundChecker)
    {
        _rb2D = rb2D;
        _groundChecker = groundChecker;
    }

    protected override void Move()
    {
        // êÖïΩà⁄ìÆ
        _rb2D.velocity =
            new Vector2(
                _moveSpeed * Input_InputManager.Instance.GetAxisRaw(_horizontalButtonName),
                _rb2D.velocity.y);
        // ÉWÉÉÉìÉv
        if (Input_InputManager.Instance.GetInputDown(_jumpButtonName) && _groundChecker.IsGround())
        {
            _rb2D.velocity = new Vector2(0f, _jumpPower);
            _isJump = true;
        }
        else
        {
            _isJump = false;
        }
    }
}