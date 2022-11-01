using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dimentionを管理するstaticクラス
/// </summary>
public class DimentionManager
{
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


    private DimentionChangeMoveMono _changeMoveMono;

    /// <summary>
    /// DimentionChangeMoveMonoを取得するためのプロパティ
    /// </summary>
    public DimentionChangeMoveMono ChangeMoveMono {set => _changeMoveMono = value; }

    private DimentionChangeMover _changeMover = new();


    /// <summary>
    /// Dimentionを行うオブジェクトのリスト
    /// </summary>
    private List<GameObject> _dimentionObjectHolder = new ();
    /// <summary>
    /// Dimentionを行うオブジェクトのリストのプロパティ
    /// </summary>
    public List<GameObject> DimentionObjectHolder { get => _dimentionObjectHolder; set => _dimentionObjectHolder = value; }

    /// <summary>
    /// Dimentionを行うキャラクターのリスト
    /// </summary>
    private List<GameObject> _dimentionCharactorHolder = new();
    /// <summary>
    /// Dimentionを行うオブジェクトのリストのプロパティ
    /// </summary>
    public List<GameObject> DimentionCharactorHolder { get => _dimentionCharactorHolder; set => _dimentionCharactorHolder = value; }


    public void DimentionChange()
    {
        
    }
}
