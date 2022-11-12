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

    /// <summary>
    /// GameObjectにIPauseがついているかチェックして、ポーズにイベントを追加するメソッド
    /// </summary>
    /// <param name="retainedObject">追加するオブジェクト</param>
    public void AddPauseResume(GameObject retainedObject)
    {
        if (retainedObject.TryGetComponent(out IPause pause))
        {
            OnPause += pause.Pause;
            OnResume += pause.Resume;
        }
    }

    /// <summary>
    /// ポーズの処理をイベントから削除するメソッド
    /// </summary>
    /// <param name="removeObject">削除するオブジェクト</param>
    public void RemovePauseResume(GameObject removeObject)
    {
        if (removeObject.TryGetComponent(out IPause pause))
        {
            OnPause -= pause.Pause;
            OnResume -= pause.Resume;
        }
    }

    /// <summary>
    /// PauseResumeが行われているか確認するため、イベントにログを追加するためのメソッド
    /// </summary>
    public void AddPauseDebug()
    {
        if (OnPause == null && OnResume == null)
        {
            OnPause += () => Debug.Log("Pauseの処理が実行されました");
            OnResume += () => Debug.Log("Resumeの処理が実行されました");
        }
    }
}
