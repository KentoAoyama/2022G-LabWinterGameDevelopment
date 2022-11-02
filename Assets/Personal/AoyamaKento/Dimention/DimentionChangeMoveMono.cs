using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviorを継承した値などを定義するクラス
/// </summary>
public class DimentionChangeMoveMono : MonoBehaviour
{
    [Tooltip("遷移するシーン")]
    [SceneName, SerializeField] string _changeSceneName;

    [Tooltip("遷移にかかる時間")] float _sceneChangeTime = 1.0f;

    [Tooltip("遷移の際にポーズを行うためのクラス")] 

    private void Start()
    {
        DimentionManager.Instance.ChangeMoveMono = this;
    }
}
