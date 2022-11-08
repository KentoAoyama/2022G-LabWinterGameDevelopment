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
    /// シーンの遷移を開始するためのクラス
    /// </summary>
    /// <param name="sceneName">遷移するシーンの名前</param>
    /// <param name="changeInterval">シーンの遷移にかける時間</param>
    /// <returns></returns>
    public IEnumerator DimentionChangeStart(string sceneName, float changeInterval = 1.0f)
    {
        PauseManager.Instance.OnPause();
        GameStateManager.Instance.GameState = GameStateManager.InGameState.DimentionChange;

        yield return new WaitForSeconds(changeInterval);

        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// シーンの変更完了後の処理
    /// </summary>
    /// <param name="finishInterval">シーン遷移後の演出にかける時間</param>
    public IEnumerator DimentionChangeFinish(float finishInterval = 1.0f)
    {
        PauseManager.Instance.OnPause();

        yield return new WaitForSeconds(finishInterval);

        PauseManager.Instance.OnResume();
    }
}
