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
        // �����Ă���������X�V����
        FacingDirectionUpdate();
    }


    private void FacingDirectionUpdate()
    {
        // x���̑��x��0�łȂ���΁A�����Ă��������\���ϐ����X�V����B
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