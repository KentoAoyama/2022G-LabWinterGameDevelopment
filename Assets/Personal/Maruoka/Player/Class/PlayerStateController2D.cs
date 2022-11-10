using System;
using UnityEngine;

[System.Serializable]
public class PlayerStateController2D : PlayerStateController
{
    private Rigidbody2D _rb2D = default;

    public void Init(Rigidbody2D rb2D)
    {
        _rb2D = rb2D;
    }
    public override void Update()
    {
        StateUpdate();
        FacingDirectionUpdate();
    }

    private void StateUpdate()
    {
        // ここにステートを更新する処理を記述する。
        var state = PlayerState.IDLE;

        _nowState = state;
    }

    private void FacingDirectionUpdate() 
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
    }
}