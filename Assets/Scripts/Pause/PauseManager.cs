using UnityEngine;
using System;

public class PauseManager
{
    //�N���X��Singleton�ɂ���
    private static PauseManager _instance = new();
    public static PauseManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"Error! Please correct!");
            }
            return _instance;
        }
    }
    private PauseManager() { }

    /// <summary>
    /// �ꎞ��~�̏�����o�^����f���Q�[�g�v���p�e�B
    /// </summary>
    public Action OnPause;

    /// <summary>
    /// �ꎞ��~�ĊJ�̏�����o�^����f���Q�[�g�v���p�e�B
    /// </summary>
    public Action OnResume;

    /// <summary>
    /// PauseResume���s���Ă��邩�m�F���邽�߁A�C�x���g�Ƀ��O��ǉ����邽�߂̃��\�b�h
    /// </summary>
    public void AddPauseDebug()
    {
        if (OnPause == null && OnResume == null)
        {
            OnPause += () => Debug.Log("Pause�̏��������s����܂���");
            OnResume += () => Debug.Log("Resume�̏��������s����܂���");
        }
    }
}
