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

    private static InGameState _gameState;

    /// <summary>
    /// 外部からStateを参照、変更する用のプロパティ
    /// </summary>
    public InGameState GameState { get => _gameState; set => _gameState = value; }

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
}
