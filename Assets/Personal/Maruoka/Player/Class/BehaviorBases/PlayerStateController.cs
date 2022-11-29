using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerStateController
{
    /// <summary> プレイヤーが現在向いている方向 </summary>
    public FacingDirection FacingDirection { get; protected set; }
    /// <summary> 現在のステート </summary>
    public PlayerState CurrentState { get => _nowState; set => _nowState = value; }
    [SerializeField]
    protected PlayerState _nowState;

    /// <summary> 更新処理 </summary>
    public abstract void Update();
    public abstract void StateClear();
}

/// <summary>
/// 向いている方向を表す型
/// </summary>
public enum FacingDirection
{
    RIGHT,
    LEFT
}