using UnityEngine;
using System;

public class GameStateManager
{
    //クラスをSingletonにする
    private static GameStateManager _instance = new();
    public static GameStateManager Instance
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
    private GameStateManager() { }

    private InGameState _gameState;
    /// <summary>
    /// InGameStateを外部から参照する用のプロパティ
    /// </summary>
    public InGameState GameState => _gameState;

    public enum InGameState
    {
        /// <summary>
        /// ゲームスタート演出中であることを表す
        /// </summary>
        Start,

        /// <summary>
        /// ゲームシーンが２Dのものであることを表す
        /// </summary>
        Game2D,

        /// <summary>
        /// ゲームシーンが３Dであることを表す
        /// </summary>
        Game3D,

        /// <summary>
        /// イベントムービーが流れている状態
        /// </summary>
        Movie,

        /// <summary>
        /// 次元の変更中であることを表す
        /// </summary>
        DimentionChange,

        /// <summary>
        /// プレイヤーがゴールしている状態を表す
        /// </summary>
        Goal
    }

    /// <summary>
    /// GameStateの変更を行う際に呼び出すメソッド
    /// </summary>
    /// <param name="gameState">変更するState</param>
    public void GameStateChange(InGameState gameState)
    {
        InGameState beforeState = _gameState;
        _gameState = gameState;
        Debug.Log($"GameStateが{beforeState}から、{_gameState}に変更されました。");
    }
}
