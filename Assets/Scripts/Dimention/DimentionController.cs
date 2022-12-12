using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.UI;

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

    [Tooltip("変化させるGlovalVolume")]
    [SerializeField] private Volume _glovalVolume;

    [Tooltip("変化させるPanel")]
    [SerializeField] private Image _panelImage;

    [Header("遷移時に出すプレハブ")]

    [Header("2Dのプレハブ")]
    [Tooltip("2Dのプレハブをまとめて持つ構造体")]
    [SerializeField] private DimentionPrefabs _dimentionObjects2d;

    [Header("3Dのプレハブ")]
    [Tooltip("3Dのプレハブをまとめて持つ構造体")]
    [SerializeField] private DimentionPrefabs _dimentionObjects3d;

    /// <summary>
    /// GlovalVolumeのweightを変化させる値
    /// </summary>
    private const float WEIGHT_VALUE = 1.0f;


    private void Start()
    {
        if (GameStateManager.Instance.GameState == GameStateManager.InGameState.DimentionChange)
        {
            //weightの値を1.0にしておく
            _glovalVolume.weight = WEIGHT_VALUE;

            if (DimentionManager.Instance.BeforeState == GameStateManager.InGameState.Game3D)
            {
                StartCoroutine
                    (DimentionManager.Instance
                    .DimentionChangeFinish(
                        _dimentionObjects2d, 
                        FadeDimention(0f)));
            }
            else if (DimentionManager.Instance.BeforeState == GameStateManager.InGameState.Game2D)
            {
                StartCoroutine(
                    DimentionManager.Instance
                    .DimentionChangeFinish(
                        _dimentionObjects3d,
                        FadeDimention(0f)));
            }
        }
        else if (GameStateManager.Instance.GameState == GameStateManager.InGameState.Start)
        {
            GameStateManager.Instance
                .GameStateChange(
                GameStateManager.InGameState.Game2D);
        }
    }

    /// <summary>
    /// プレイヤーが呼び出すDimentionの変更を行うメソッド
    /// </summary>
    public void DimentionChange()
    {
        if (GameStateManager.Instance.GameState != GameStateManager.InGameState.DimentionChange)
        {
            StartCoroutine(
                DimentionManager.Instance
                .DimentionChangeStart(
                    _changeSceneName, 
                    FadeDimention(WEIGHT_VALUE)));
        }
    }

    private IEnumerator FadeDimention(float changeValue)
    {
        _panelImage.DOFade(
            changeValue, 
            _changeSceneTime);

        yield return DOTween.To(
            () => _glovalVolume.weight,
            (x) => _glovalVolume.weight = x, 
            changeValue, 
            _changeSceneTime)
            .WaitForCompletion();       
    }
}
