using System;
using UnityEngine;

[System.Serializable]
public class PlayerStateController3D : PlayerStateController
{
    public PlayerStateController3D(Rigidbody rb)
    {
        _rb = rb;
    }

    private readonly Rigidbody _rb = default;

    public override void Update()
    {
        // 向いている方向を更新する
        FacingDirectionUpdate();
    }


    private void FacingDirectionUpdate()
    {
        // x軸の速度が0でなければ、向いている方向を表す変数を更新する。
        if (!Mathf.Approximately(_rb.velocity.x, 0f))
        {
            if (_rb.velocity.x > 0f)
            {
                FacingDirection = FacingDirection.RIGHT;
            }
            else if (_rb.velocity.x < 0f)
            {
                FacingDirection = FacingDirection.LEFT;
            }
        }
    }
}