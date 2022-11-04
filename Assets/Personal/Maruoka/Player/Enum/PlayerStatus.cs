using System;
using UnityEngine;

/// <summary>
/// �v���C���[���\���X�e�[�g�ꗗ(�A�j���[�V�����̐������S�ėp�ӂ���B)
/// </summary>
[System.Serializable]
public enum PlayerState
{
    /// <summary>
    /// �ҋ@
    /// </summary>
    IDLE,
    /// <summary>
    /// �ړ�
    /// </summary>
    MOVE,
    /// <summary>
    /// �W�����v 2D�̂�
    /// </summary>
    JUMP_2D,
    /// <summary>
    /// �X�e�b�v 3D�̂�
    /// </summary>
    STEP_3D,
    /// <summary>
    /// �_���[�W�����炤
    /// </summary>
    DAMAGE,
    /// <summary>
    /// �����ɉ΂�����
    /// </summary>
    SET_FIRE_TORCH,
    /// <summary>
    /// ����
    /// </summary>
    FALL,
    /// <summary>
    /// �U��
    /// </summary>
    ON_FIRE
}