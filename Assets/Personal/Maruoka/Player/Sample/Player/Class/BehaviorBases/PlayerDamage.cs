using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerDamage
{
    [SerializeField]
    protected bool _isGodMode = false;

    public bool IsGodMode => _isGodMode;

    public abstract void OnDamage(int value);
}