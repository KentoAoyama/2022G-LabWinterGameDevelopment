using UnityEngine;

/// <summary>
/// MonoBehavior���p�������l�Ȃǂ��`����N���X
/// </summary>
public class DimentionController : MonoBehaviour
{
    [Tooltip("�J�ڂ���V�[��")]
    [SceneName, SerializeField] private string _changeSceneName;

    [Tooltip("�J�ڂɂ����鎞��")]
    [SerializeField] private float _changeSceneTime = 1.0f;

    private void Start()
    {
        if (GameStateManager.Instance.GameState == GameStateManager.InGameState.DimentionChange)
        {
            DimentionManager.Instance.DimentionChangeFinish(_changeSceneTime);
        }
    }

    /// <summary>
    /// �v���C���[���Ăяo��Dimention�̕ύX���s�����\�b�h
    /// </summary>
    public void DimentionChange()
    {
        DimentionManager.Instance.DimentionChangeStart(_changeSceneName, _changeSceneTime);
    }
}
