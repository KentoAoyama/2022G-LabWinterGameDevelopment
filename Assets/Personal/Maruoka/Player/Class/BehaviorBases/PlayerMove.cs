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
                // Debug.Log("�v���C���[���ړ��\�ɂ��܂�");
            }
            else
            {
                // Debug.LogWarning("�v���C���[���ړ��s�ɂ��܂�");
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