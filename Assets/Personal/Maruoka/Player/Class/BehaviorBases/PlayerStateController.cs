using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerStateController
{
    /// <summary> �v���C���[�����݌����Ă������ </summary>
    public FacingDirection FacingDirection { get; protected set; }
    public PlayerState NowState => _nowState;

    protected PlayerState _nowState;
    /// <summary> �X�V���� </summary>
    public abstract void Update();
}

/// <summary>
/// �����Ă��������\���^
/// </summary>
public enum FacingDirection
{
    RIGHT,
    LEFT
}