using System.Collections;
using System.Collections.Generic;
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

    }

    public void DimentionChange()
    {
        DimentionManager.Instance.DimentionChange(_changeSceneName);
    }
}
