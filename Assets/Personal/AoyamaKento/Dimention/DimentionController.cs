using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviorを継承した値などを定義するクラス
/// </summary>
public class DimentionChangeMoveMono : MonoBehaviour
{
    [Tooltip("遷移するシーン")]
    [SceneName, SerializeField] private string _changeSceneName;

    [Tooltip("遷移にかかる時間")]
    [SerializeField] private float _changeSceneTime = 1.0f;

    /// <summary>
    /// 遷移するシーンの名前のプロパティ
    /// </summary>
    public string ChangeSceneName => _changeSceneName;
    /// <summary>
    /// シーンの遷移にかかる時間のプロパティ
    /// </summary>
    public float ChangeSceneTime => _changeSceneTime;

    private void Start()
    {

    }
}
