/// <summary>
/// �v���C���[���\���X�e�[�g�ꗗ(�A�j���[�V�����̐������S�ėp�ӂ���B)
/// </summary>
[System.Serializable]
public enum PlayerState
{
    /// <summary> �ҋ@ </summary>
    IDLE,
    /// <summary> �ړ� </summary>
    MOVE,
    /// <summary> �_���[�W�����炤 </summary>
    DAMAGE,
    /// <summary> �M�~�b�N���쒆 </summary>
    ACTION,
    /// <summary> �㏸ </summary>
    RISE,
    /// <summary> ���� </summary>
    FALL,
    /// <summary> �U�� </summary>
    ATTACK,
    /// <summary> �W�����v 2D�̂� </summary>
    JUMP_2D,
    /// <summary> �X�e�b�v 3D�̂� </summary>
    STEP_3D,
}