using UnityEngine;

public interface IGimmickEvent
{
    /// <summary>
    /// プレイヤーのアニメーションを再生するかを判定する用のプロパティ
    /// </summary>
    public bool IsPlayAnimation { get; }

    /// <summary>
    /// IGameEventによって実装される、ギミックが作動した時に実行されるメソッド
    /// </summary>
    protected void GimmickEvent();
}
