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
}
