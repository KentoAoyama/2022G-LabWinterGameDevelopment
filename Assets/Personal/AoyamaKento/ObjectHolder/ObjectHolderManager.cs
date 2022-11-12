using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// RetainedObjectBehaviorを継承したクラスを持つゲームオブジェクトを管理するクラス
/// </summary>
public class ObjectHolderManager
{
    //シングルトン
    #region Singleton
    private static ObjectHolderManager _instance = new ObjectHolderManager();
    public static ObjectHolderManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError($"Error! Please correct!");
            }
            return _instance;
        }
    }
    private ObjectHolderManager(){}
    #endregion

    //メンバー変数
    #region Member Variables

    /// PlayerのGameObjectを持つ変数
    /// </summary>
    private GameObject _playerHolder = null;
    #endregion

    //プロパティ
    #region Properties

    /// <summary>
    /// Playerの参照・取得を行うためのプロパティ
    /// </summary>
    public GameObject PlayerHolder { get => _playerHolder; set => _playerHolder = value; }
    #endregion

    //パブリックメソッド
    #region Public Methods

    /// <summary>
    /// ObjectHolderにオブジェクトを追加する際に呼び出すメソッド
    /// </summary>
    public void AddHolder(GameObject retainedObject)
    {
        PauseManager.Instance.AddPauseResume(retainedObject);
        DimentionManager.Instance.AddDimentionHolder(retainedObject);
    }

    /// <summary>
    /// ObjectHolderからオブジェクトを削除する際に呼び出すメソッド
    /// </summary>
    public void RemoveHolder(GameObject removeObject)
    {
        PauseManager.Instance.RemovePauseResume(removeObject);
        DimentionManager.Instance.RemoveDimentionHolder(removeObject);
    }
    #endregion

    //プライベートメソッド
    #region Private Methods
    #endregion
}