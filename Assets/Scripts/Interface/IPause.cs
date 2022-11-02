using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPause
{
    /// <summary>
    /// PauseManager��PauseResume��o�^���邽�߂̃��\�b�h
    /// �����Start�ŌĂяo��
    /// </summary>
    protected void SetPauseResume();

    /// <summary>
    /// PauseManager����PauseResume���폜���邽�߂̃��\�b�h
    /// �����OnDisable�ŌĂяo��
    /// </summary>
    protected void RemovePauseResume();

    /// <summary>
    /// IPause�ɂ���Ď��������A�|�[�Y���s�����ۂɎ��s����郁�\�b�h
    /// </summary>
    public void Pause();

    /// <summary>
    /// IPause�ɂ���Ď��������A�|�[�Y�����������ۂɎ��s����郁�\�b�h
    /// </summary>
    public void Resume();
}

