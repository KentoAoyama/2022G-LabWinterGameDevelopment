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
        // �����Ă���������X�V����
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
        // �X�e�[�g���X�V����
        var state = PlayerState.IDLE;


        _nowState = state;
    }
}