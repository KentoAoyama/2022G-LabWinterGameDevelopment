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
    private DimentionManager() { }
    #endregion

    //メンバー変数
    #region Member Variables  

    /// <summary>
    /// 敵のリスト
    /// </summary>
    private List<GameObject> _enemyHolder = new();

    /// <summary>
    /// Dimentionを行うオブジェクトのリスト
    /// </summary>
    private List<GameObject> _enemyBulletHolder = new();

    /// <summary>
    /// シーン遷移時に座標を保管しておくための変数
    /// </summary>
    private Transform _playerPosition;

    /// <summary>
    /// シーン遷移時に座標を保管しておくための変数
    /// </summary>
    private List<EnemyStatus> _enemyStatus = new();

    /// <summary>
    /// シーン遷移時に座標を保管しておくための変数
    /// </summary>
    private List<EnemyBulletStatus> _enemyBulletStatus = new();

    /// <summary>
    /// シーンの遷移を行う前のStateを保存しておく用の変数
    /// </summary>
    GameStateManager.InGameState _beforeState;
    #endregion

    //プロパティ
    #region Properties
    #endregion

    //パブリックメソッド
    #region Public Methods

    /// <summary>
    /// DimentionHolderにGameObjectを追加するためのメソッド
    /// </summary>
    /// <param name="retainedObject">追加するオブジェクト</param>
    public void AddDimentionHolder(GameObject retainedObject)
    {
        //敵をEnemyHolderに登録
        if (retainedObject.TryGetComponent(out RetainedEnemyBehavior _))
        {
            _enemyHolder.Add(retainedObject);
        }
        //敵の弾をObjectHolderに登録
        else if (retainedObject.TryGetComponent(out RetainedEnemyBulletBehavior _))
        {
            _enemyBulletHolder.Add(retainedObject);
        }
    }

    /// <summary>
    /// DimentionHolderからGameObjectを削除するためのメソッド
    /// </summary>
    /// <param name="removeObject">削除するオブジェクト</param>
    public void RemoveDimentionHolder(GameObject removeObject)
    {
        //敵をEnemyHolderから削除
        if (removeObject.TryGetComponent(out RetainedEnemyBehavior _))
        {
            _enemyHolder.Remove(removeObject);
        }
        //プレイヤー・敵の弾から削除
        else if (removeObject.TryGetComponent(out RetainedEnemyBulletBehavior _))
        {
            _enemyBulletHolder.Remove(removeObject);
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
        //GameStateの3D2Dを判定
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

    /// <summary>
    /// Enemyの情報をEnemyStatus型のListに保存する処理
    /// </summary>
    private void SaveEnemyStatus() 
    {
        foreach (GameObject enemy in _enemyHolder)
        {
            //EnemyStatus enemyStatus = new();
            //EnemyController enemyController = enemy.GetComponent<EnemyController>();
            
        }
    }

    /// <summary>
    /// ObjectHolderに格納されているGameObjectの座標をListに保存する処理
    /// </summary>
    private void SaveEnemyBulletStatus()
    {
        foreach (GameObject enemyBullet in _enemyBulletHolder)
        {
            //EnemyBulletStatus enemyBulletStatus = new();
            //EnemyBulletController enemyBulletController = enemyBullet.GetComponent<EnemyBulletController>();
        }
    }

    /// <summary>
    /// DimentionChange後にオブジェクトを前のシーンの位置に出す処理
    /// </summary>
    private void DimenitonChangeObject()
    {

    }
    #endregion
}