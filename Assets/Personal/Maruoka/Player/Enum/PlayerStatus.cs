using System;
using UnityEngine;

/// <summary>
/// プレイヤーが表すステート一覧(アニメーションの数だけ全て用意する。)
/// </summary>
[System.Serializable]
public enum PlayerState
{
    /// <summary>
    /// 待機
    /// </summary>
    IDLE,
    /// <summary>
    /// 移動
    /// </summary>
    MOVE,
    /// <summary>
    /// ジャンプ 2Dのみ
    /// </summary>
    JUMP_2D,
    /// <summary>
    /// ステップ 3Dのみ
    /// </summary>
    STEP_3D,
    /// <summary>
    /// ダメージをくらう
    /// </summary>
    DAMAGE,
    /// <summary>
    /// 松明に火をつける
    /// </summary>
    SET_FIRE_TORCH,
    /// <summary>
    /// 落下
    /// </summary>
    FALL,
    /// <summary>
    /// 攻撃
    /// </summary>
    ON_FIRE
}