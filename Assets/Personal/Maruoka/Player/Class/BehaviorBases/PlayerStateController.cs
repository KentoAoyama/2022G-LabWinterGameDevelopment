using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerStateController
{
    /// <summary> プレイヤーが現在向いている方向 </summary>
    public FacingDirection FacingDirection { get; protected set; }
    /// <summary> 現在のステート </summary>
    public PlayerState NowState => _nowState;
    [SerializeField]
    protected PlayerState _nowState;

    /// <summary> 更新処理 </summary>
    public abstract void Update();
}

/// <summary>
/// 向いている方向を表す型
/// </summary>
public enum FacingDirection
{
    RIGHT,
    LEFT
}