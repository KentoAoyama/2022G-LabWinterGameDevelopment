using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundManager", menuName = "ScriptableObjects/SoundScriptableObject", order = 1)]
public class SoundScriptableObject : ScriptableObject
{
    [Header("Audioのプレハブ")]
    [SerializeField] private GameObject _audioPrefab;

    [Header("再生するサウンドのデータ")]
    [SerializeField] private Sounds _soundsData;

    [Header("生成したオブジェクトを削除する時間")]
    [SerializeField] private float _destroyIntereval = 2.0f;

    /// <summary>
    /// Audioを再生するためのプレハブのプロパティ
    /// </summary>
    public GameObject AudioPrefab => _audioPrefab;

    /// <summary>
    /// 再生するサウンドのデータのプレハブ
    /// </summary>
    public Sounds SoundsData => _soundsData;

    /// <summary>
    /// 生成したオブジェクトを削除するまでの時間のプロパティ
    /// </summary>
    public float DestroyInterval => _destroyIntereval;
}