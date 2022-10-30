using System;
using UnityEngine;

[System.Serializable]
public class PlayerMove3D : PlayerMove
{
    private readonly SelfMadeInput _inputer = new Input_InputManager();
    private readonly string _horizontalButtonName = "";

    private Rigidbody _rb;
    private float _moveSpeed;

    public PlayerMove3D(Component rb, float moveSpeed,string horizontalButtonName)
    {
        Init(rb);
        _moveSpeed = moveSpeed;
    }

    protected override void Init(Component rb)
    {
        if (rb is Rigidbody)
        {
            _rb = rb as Rigidbody;
           
        }
#if UNITY_EDITOR
        else if (rb == null)
        {
            Debug.LogError("����\"rb\"��null�ł��I");
        }
        else
        {
            Debug.LogError("����\"rb\"���s���ł��I");
        }
#endif
    }


    public override void Move()
    {
        // �����ړ�
        _rb.velocity =
            new Vector2(
                _moveSpeed * _inputer.GetAxisRaw(_horizontalButtonName),
                _rb.velocity.y);

        // ���s���ړ�
        throw new NotImplementedException();
    }
}