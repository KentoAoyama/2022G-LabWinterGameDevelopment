using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehavior���p�������l�Ȃǂ��`����N���X
/// </summary>
public class DimentionChangeMoveMono : MonoBehaviour
{
    [Tooltip("�J�ڂ���V�[��")]
    [SceneName, SerializeField] string _changeSceneName;

    [Tooltip("�J�ڂɂ����鎞��")] float _sceneChangeTime = 1.0f;

    [Tooltip("�J�ڂ̍ۂɃ|�[�Y���s�����߂̃N���X")] 

    private void Start()
    {
        DimentionManager.Instance.ChangeMoveMono = this;
    }
}
