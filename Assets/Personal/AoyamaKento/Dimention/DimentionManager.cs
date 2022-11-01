using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dimention���Ǘ�����static�N���X
/// </summary>
public class DimentionManager : MonoBehaviour
{
    DementionChangeMover _mover;

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


    private void Start()
    {
        
    }
}
