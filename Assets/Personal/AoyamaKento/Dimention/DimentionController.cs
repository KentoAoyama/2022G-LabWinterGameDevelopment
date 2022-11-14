using UnityEngine;

/// <summary>
/// MonoBehaviorを継承した値などを定義するクラス
/// </summary>
public class DimentionController : MonoBehaviour
{
    [Header("Dimentionの設定")]

    [Tooltip("遷移するシーン")]
    [SceneName, SerializeField] private string _changeSceneName;
    [Tooltip("遷移にかかる時間")]
    [SerializeField] private float _changeSceneTime = 1.0f;

    [Header("遷移時に出すプレハブ")]

    [Header("2Dのプレハブ")]
    [Tooltip("2Dのプレハブをまとめて持つ構造体")]
    [SerializeField] private DimentionPrefabs _dimentionObjects2d;

    [Header("3Dのプレハブ")]
    [Tooltip("3Dのプレハブをまとめて持つ構造体")]
    [SerializeField] private DimentionPrefabs _dimentionObjects3d;


    private void Start()
    {
        if (GameStateManager.Instance.GameState == GameStateManager.InGameState.DimentionChange)
        {
            if(DimentionManager.Instance.BeforeState == GameStateManager.InGameState.Game3D)
            {
                StartCoroutine(DimentionManager.Instance.DimentionChangeFinish(_dimentionObjects2d, _changeSceneTime));
            }
            else if (DimentionManager.Instance.BeforeState == GameStateManager.InGameState.Game2D)
            {
                StartCoroutine(DimentionManager.Instance.DimentionChangeFinish(_dimentionObjects3d, _changeSceneTime));
            }
        }
    }

    /// <summary>
    /// プレイヤーが呼び出すDimentionの変更を行うメソッド
    /// </summary>
    public void DimentionChange()
    {
        StartCoroutine(DimentionManager.Instance.DimentionChangeStart(_changeSceneName, _changeSceneTime));        
    }
}
