using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    /// <summary>
    /// Sceneの遷移を行うためのクラス
    /// </summary>
    /// <param name="sceneName"></param>
    public void DimentionChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
