using System;
using UnityEngine;

[System.Serializable]
public class PlayerMove3D : PlayerMove
{
    private readonly SelfMadeInput _inputer = new Input_InputManager();
    private readonly string _horizontalButtonName = "";

    private Rigidbody _rb;
    private float _moveSpeed;
    private bool _isMove = true;

    public bool IsMove 
    { 
        get => _isMove;
        set 
        {
            if (value)
            {
                Debug.Log("プレイヤーを移動可能にします");
            }
            else
            {
                Debug.LogWarning("プレイヤーを移動不可にします");
            }
            _isMove = value; 
        } 
    }

    public PlayerMove3D(
        Component rb, float moveSpeed,
        string horizontalButtonName)
    {
        Init(rb);
        _moveSpeed = moveSpeed;
        _horizontalButtonName = horizontalButtonName;
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
            Debug.LogError("引数\"rb\"がnullです！");
        }
        else
        {
            Debug.LogError("引数\"rb\"が不正です！");
        }
#endif
    }


    public override void Move()
    {
        // 水平移動
        _rb.velocity =
            new Vector3(
                _moveSpeed * _inputer.GetAxisRaw(_horizontalButtonName),
                _rb.velocity.y,
                0.0f
                );
    }
}