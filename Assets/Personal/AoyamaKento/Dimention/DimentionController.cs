using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehavior���p�������l�Ȃǂ��`����N���X
/// </summary>
public class DimentionChangeMoveMono : MonoBehaviour
{
    [Tooltip("�J�ڂ���V�[��")]
    [SceneName, SerializeField] private string _changeSceneName;

    [Tooltip("�J�ڂɂ����鎞��")]
    [SerializeField] private float _changeSceneTime = 1.0f;

    /// <summary>
    /// �J�ڂ���V�[���̖��O�̃v���p�e�B
    /// </summary>
    public string ChangeSceneName => _changeSceneName;
    /// <summary>
    /// �V�[���̑J�ڂɂ����鎞�Ԃ̃v���p�e�B
    /// </summary>
    public float ChangeSceneTime => _changeSceneTime;

    private void Start()
    {

    }
}
