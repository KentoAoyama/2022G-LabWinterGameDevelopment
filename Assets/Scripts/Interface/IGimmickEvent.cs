using UnityEngine;

public interface IGimmickEvent
{
    /// <summary>
    /// �v���C���[�̃A�j���[�V�������Đ����邩�𔻒肷��p�̃v���p�e�B
    /// </summary>
    public bool IsPlayAnimation { get; }

    /// <summary>
    /// IGameEvent�ɂ���Ď��������A�M�~�b�N���쓮�������Ɏ��s����郁�\�b�h
    /// </summary>
    protected void GimmickEvent();
}
