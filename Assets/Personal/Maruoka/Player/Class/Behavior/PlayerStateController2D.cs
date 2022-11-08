using System;
using UnityEngine;

[System.Serializable]
public class PlayerStateController2D : PlayerStateController
{
    public PlayerStateController2D(Rigidbody2D rb2D)
    {
        _rb2D = rb2D;
    }

    private readonly Rigidbody2D _rb2D = default;

    public override void Update()
    {
        // 向いている方向を更新する
        if (!Mathf.Approximately(_rb2D.velocity.x, 0f))
        {
            if (_rb2D.velocity.x > 0f)
            {
                FacingDirection = FacingDirection.RIGHT;
            }
            else if (_rb2D.velocity.x < 0f)
            {
                FacingDirection = FacingDirection.LEFT;
            }
        }
        // ステートを更新する
        var state = PlayerState.IDLE;


        _nowState = state;
    }
}