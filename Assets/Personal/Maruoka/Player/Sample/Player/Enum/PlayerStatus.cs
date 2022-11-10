/// <summary>
/// プレイヤーが表すステート一覧(アニメーションの数だけ全て用意する。)
/// </summary>
[System.Serializable]
public enum PlayerState
{
    /// <summary> 待機 </summary>
    IDLE,
    /// <summary> 移動 </summary>
    MOVE,
    /// <summary> ダメージをくらう </summary>
    DAMAGE,
    /// <summary> ギミック操作中 </summary>
    ACTION,
    /// <summary> 上昇 </summary>
    RISE,
    /// <summary> 落下 </summary>
    FALL,
    /// <summary> 攻撃 </summary>
    ATTACK,
    /// <summary> ジャンプ 2Dのみ </summary>
    JUMP_2D,
    /// <summary> ステップ 3Dのみ </summary>
    STEP_3D,
}