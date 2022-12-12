using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.UI;

/// <summary>
/// MonoBehavior���p�������l�Ȃǂ��`����N���X
/// </summary>
public class DimentionController : MonoBehaviour
{
    [Header("Dimention�̐ݒ�")]

    [Tooltip("�J�ڂ���V�[��")]
    [SceneName, SerializeField] private string _changeSceneName;

    [Tooltip("�J�ڂɂ����鎞��")]
    [SerializeField] private float _changeSceneTime = 1.0f;

    [Tooltip("�ω�������GlovalVolume")]
    [SerializeField] private Volume _glovalVolume;

    [Tooltip("�ω�������Panel")]
    [SerializeField] private Image _panelImage;

    [Header("�J�ڎ��ɏo���v���n�u")]

    [Header("2D�̃v���n�u")]
    [Tooltip("2D�̃v���n�u���܂Ƃ߂Ď��\����")]
    [SerializeField] private DimentionPrefabs _dimentionObjects2d;

    [Header("3D�̃v���n�u")]
    [Tooltip("3D�̃v���n�u���܂Ƃ߂Ď��\����")]
    [SerializeField] private DimentionPrefabs _dimentionObjects3d;

    /// <summary>
    /// GlovalVolume��weight��ω�������l
    /// </summary>
    private const float WEIGHT_VALUE = 1.0f;


    private void Start()
    {
        if (GameStateManager.Instance.GameState == GameStateManager.InGameState.DimentionChange)
        {
            //weight�̒l��1.0�ɂ��Ă���
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
    /// �v���C���[���Ăяo��Dimention�̕ύX���s�����\�b�h
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
