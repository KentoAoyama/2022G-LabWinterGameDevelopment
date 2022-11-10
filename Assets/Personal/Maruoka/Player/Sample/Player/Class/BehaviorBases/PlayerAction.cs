using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerAction
{
    public abstract void OnActionEnter(IGimmickEvent gimmick);
    public abstract void OnActionExit(IGimmickEvent gimmick);
}