using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerStateController
{
    /// <summary> �v���C���[�����݌����Ă������ </summary>
    public FacingDirection FacingDirection { get; protected set; }
    /// <summary> ���݂̃X�e�[�g </summary>
    public PlayerState CurrentState { get => _nowState; set => _nowState = value; }
    [SerializeField]
    protected PlayerState _nowState;

    /// <summary> �X�V���� </summary>
    public abstract void Update();
    public abstract void StateClear();
}

/// <summary>
/// �����Ă��������\���^
/// </summary>
public enum FacingDirection
{
    RIGHT,
    LEFT
}