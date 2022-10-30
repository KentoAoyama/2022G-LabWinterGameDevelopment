using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerMove
{
    protected abstract void Init(Component rb);
    public abstract void Move();
}