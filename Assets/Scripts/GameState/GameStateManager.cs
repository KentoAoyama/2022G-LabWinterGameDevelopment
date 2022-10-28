public class GameStateManager
{
    private static InGameState _gameState;

    /// <summary>
    /// 外部からStateを参照して確認する用のプロパティ
    /// </summary>
    public InGameState GameState => _gameState;

    /// <summary>
    /// 外部からStateを変更する用のメソッド
    /// </summary>
    /// <param name="gameState">変更するState</param>
    public static void ChangeState(InGameState gameState)
    {
        _gameState = gameState;
    }

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
        /// ゲームがポーズ中であることを表す
        /// </summary>
        Pause,

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
