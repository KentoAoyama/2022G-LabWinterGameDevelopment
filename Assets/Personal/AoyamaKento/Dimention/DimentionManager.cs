using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    private DimentionChangeMoveMono _changeMoveMono;

    /// <summary>
    /// DimentionChangeMoveMono���擾���邽�߂̃v���p�e�B
    /// </summary>
    public DimentionChangeMoveMono ChangeMoveMono {set => _changeMoveMono = value; }

    private DimentionChangeMover _changeMover = new();


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


    public void DimentionChange()
    {
        
    }
}
