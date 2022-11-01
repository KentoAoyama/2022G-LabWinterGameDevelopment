using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dimentionを管理するstaticクラス
/// </summary>
public class DimentionManager : MonoBehaviour
{
    DementionChangeMover _mover;

    //クラスをSingletonにする
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
    /// Dimentionを行うオブジェクトのリスト
    /// </summary>
    private List<GameObject> _dimentionObjectHolder = new ();
    /// <summary>
    /// Dimentionを行うオブジェクトのリストのプロパティ
    /// </summary>
    public List<GameObject> DimentionObjectHolder { get => _dimentionObjectHolder; set => _dimentionObjectHolder = value; }


    private void Start()
    {
        
    }
}
