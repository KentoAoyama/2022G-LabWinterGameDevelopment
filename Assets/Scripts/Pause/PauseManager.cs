using UnityEngine;
using System;

public class PauseManager
{
    //クラスをSingletonにする
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
    /// 一時停止の処理を登録するデリゲートプロパティ
    /// </summary>
    public Action OnPause;

    /// <summary>
    /// 一時停止再開の処理を登録するデリゲートプロパティ
    /// </summary>
    public Action OnResume;
}
