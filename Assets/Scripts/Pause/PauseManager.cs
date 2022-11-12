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
    /// GameObject��IPause�����Ă��邩�`�F�b�N���āA�|�[�Y�ɃC�x���g��ǉ����郁�\�b�h
    /// </summary>
    /// <param name="retainedObject">�ǉ�����I�u�W�F�N�g</param>
    public void AddPauseResume(GameObject retainedObject)
    {
        if (retainedObject.TryGetComponent(out IPause pause))
        {
            OnPause += pause.Pause;
            OnResume += pause.Resume;
        }
    }

    /// <summary>
    /// �|�[�Y�̏������C�x���g����폜���郁�\�b�h
    /// </summary>
    /// <param name="removeObject">�폜����I�u�W�F�N�g</param>
    public void RemovePauseResume(GameObject removeObject)
    {
        if (removeObject.TryGetComponent(out IPause pause))
        {
            OnPause -= pause.Pause;
            OnResume -= pause.Resume;
        }
    }

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
