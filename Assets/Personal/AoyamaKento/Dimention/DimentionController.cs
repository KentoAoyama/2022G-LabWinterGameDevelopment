using System.Collections;
using System.Collections.Generic;
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

    }

    public void DimentionChange()
    {
        DimentionManager.Instance.DimentionChange(_changeSceneName);
    }
}
