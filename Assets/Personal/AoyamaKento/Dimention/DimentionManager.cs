using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Dimention���Ǘ�����static�N���X
/// </summary>
public class DimentionManager
{
    //�N���X��Singleton�ɂ���
    private static DimentionManager _instance = new ();
    public static DimentionManager Instance
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
    private DimentionManager() { }


    /// <summary>
    /// Dimention���s���I�u�W�F�N�g�̃��X�g
    /// </summary>
    private List<GameObject> _dimentionObjectHolder = new ();
    /// <summary>
    /// Dimention���s���I�u�W�F�N�g�̃��X�g�̃v���p�e�B
    /// </summary>
    public List<GameObject> DimentionObjectHolder { get => _dimentionObjectHolder; set => _dimentionObjectHolder = value; }

    /// <summary>
    /// Dimention���s���L�����N�^�[�̃��X�g
    /// </summary>
    private List<GameObject> _dimentionCharactorHolder = new();
    /// <summary>
    /// Dimention���s���I�u�W�F�N�g�̃��X�g�̃v���p�e�B
    /// </summary>
    public List<GameObject> DimentionCharactorHolder { get => _dimentionCharactorHolder; set => _dimentionCharactorHolder = value; }

    /// <summary>
    /// Scene�̑J�ڂ��s�����߂̃N���X
    /// </summary>
    /// <param name="sceneName"></param>
    public void DimentionChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
