using UnityEngine;

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

    [Header("�J�ڎ��ɏo���v���n�u")]

    [Header("2D�̃v���n�u")]
    [Tooltip("2D�̃v���n�u���܂Ƃ߂Ď��\����")]
    [SerializeField] private DimentionPrefabs _dimentionObjects2d;

    [Header("3D�̃v���n�u")]
    [Tooltip("3D�̃v���n�u���܂Ƃ߂Ď��\����")]
    [SerializeField] private DimentionPrefabs _dimentionObjects3d;


    private void Start()
    {
        if (GameStateManager.Instance.GameState == GameStateManager.InGameState.DimentionChange)
        {
            StartCoroutine(DimentionManager.Instance.DimentionChangeFinish(_changeSceneTime));
        }
    }

    /// <summary>
    /// �v���C���[���Ăяo��Dimention�̕ύX���s�����\�b�h
    /// </summary>
    public void DimentionChange()
    {
        StartCoroutine(DimentionManager.Instance.DimentionChangeStart(_changeSceneName, _changeSceneTime));        
    }
}
