using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerMove
{
    [SerializeField]
    private bool _isMove = true;

    public bool IsMove
    {
        get => _isMove;
        set
        {
            if (value)
            {
                // Debug.Log("プレイヤーを移動可能にします");
            }
            else
            {
                // Debug.LogWarning("プレイヤーを移動不可にします");
            }
            _isMove = value;
        }
    }

    public virtual void Update()
    {
        if (_isMove)
        {
            Move();
        }
    }

    protected abstract void Move();
}