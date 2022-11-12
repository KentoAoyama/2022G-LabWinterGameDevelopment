using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DimentionManager
{
    //シングルトン
    #region Singleton
    private static DimentionManager _instance = new DimentionManager();
    public static DimentionManager Instance
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
    private DimentionManager(){}
    #endregion

    //メンバー変数
    #region Member Variables

    /// <summary>
    /// Dimentionを行うオブジェクトのリスト
    /// </summary>
    private List<GameObject> _dimentionObjectHolder = new();

    /// <summary>
    /// Dimentionを行うキャラクターのリスト
    /// </summary>
    private List<GameObject> _dimentionCharactorHolder = new();

    /// <summary>
    /// シーンの遷移を行う前のStateを保存しておく用の変数
    /// </summary>
    GameStateManager.InGameState _beforeState;
    #endregion

    //プロパティ
    #region Properties
    #endregion

    //イベント
    #region Events
    #endregion

    //パブリックメソッド
    #region Public Methods

    /// <summary>
    /// DimentionHolderにGameObjectを追加するためのメソッド
    /// </summary>
    /// <param name="retainedObject">追加するオブジェクト</param>
    public void AddDimentionHolder(GameObject retainedObject)
    {
        //敵をDimenitonManagerに登録
        if (retainedObject.TryGetComponent(out EnemyController _))
        {
            _dimentionCharactorHolder.Add(retainedObject);
        }
        //プレイヤー・敵の弾をDimenitonManagerに登録
        else if (retainedObject.TryGetComponent(out PlayerController _) ||            
            retainedObject.TryGetComponent(out EnemyBulletController _))
        {
            _dimentionObjectHolder.Add(retainedObject);
        }
    }

    /// <summary>
    /// DimentionHolderからGameObjectを削除するためのメソッド
    /// </summary>
    /// <param name="removeObject">削除するオブジェクト</param>
    public void RemoveDimentionHolder(GameObject removeObject)
    {
        //敵をCharactorHolderに登録
        if (removeObject.TryGetComponent(out EnemyController _))
        {
            _dimentionCharactorHolder.Remove(removeObject);
        }
        //プレイヤー・敵の弾をObjectHolderに登録
        else if (removeObject.TryGetComponent(out PlayerController _) ||
            removeObject.TryGetComponent(out EnemyBulletController _))
        {
            _dimentionObjectHolder.Remove(removeObject);
        }
    }

    /// <summary>
    /// シーンの遷移を開始するためのクラス
    /// </summary>
    /// <param name="sceneName">遷移するシーンの名前</param>
    /// <param name="changeInterval">シーンの遷移にかける時間</param>
    /// <returns></returns>
    public IEnumerator DimentionChangeStart(string sceneName, float changeInterval = 1.0f)
    {
        Debug.Log("DimentionChangeスタート");

        //現在のステートを2D3D切り替えのために保存
        _beforeState = GameStateManager.Instance.GameState;
        //ポーズの処理を実行
        PauseManager.Instance.OnPause();
        //シーン遷移後の処理のためステートを変更
        GameStateManager.Instance.GameStateChange(GameStateManager.InGameState.DimentionChange);

        yield return new WaitForSeconds(changeInterval);

        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// シーンの変更完了後の処理
    /// </summary>
    /// <param name="finishInterval">シーン遷移後の演出にかける時間</param>
    public IEnumerator DimentionChangeFinish(float finishInterval = 1.0f)
    {
        //GameStateの3D2Dを切り替える
        if (_beforeState == GameStateManager.InGameState.Game2D)
        {
            GameStateManager.Instance.GameStateChange(GameStateManager.InGameState.Game3D);
        }
        else if (_beforeState == GameStateManager.InGameState.Game3D)
        {
            GameStateManager.Instance.GameStateChange(GameStateManager.InGameState.Game2D);
        }
        //遷移してすぐポーズを実行
        PauseManager.Instance.OnPause();

        yield return new WaitForSeconds(finishInterval);

        //演出終了後ポーズを解除
        PauseManager.Instance.OnResume();

        Debug.Log("DimentionChange終了");
    }
    #endregion

    //プライベートメソッド
    #region Private Methods
    #endregion
}