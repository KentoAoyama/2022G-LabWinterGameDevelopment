using UnityEngine;

/// <summary>
/// MonoBehaviorを継承した値などを定義するクラス
/// </summary>
public class DimentionController : MonoBehaviour
{
    [Tooltip("遷移するシーン")]
    [SceneName, SerializeField] private string _changeSceneName;

    [Tooltip("遷移にかかる時間")]
    [SerializeField] private float _changeSceneTime = 1.0f;

    private void Start()
    {
        if (GameStateManager.Instance.GameState == GameStateManager.InGameState.DimentionChange)
        {
            DimentionManager.Instance.DimentionChangeFinish(_changeSceneTime);
        }
    }

    /// <summary>
    /// プレイヤーが呼び出すDimentionの変更を行うメソッド
    /// </summary>
    public void DimentionChange()
    {
        DimentionManager.Instance.DimentionChangeStart(_changeSceneName, _changeSceneTime);
    }
}
