using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundManager", menuName = "ScriptableObjects/SoundScriptableObject", order = 1)]
public class SoundScriptableObject : ScriptableObject
{
    [Header("Audio�̃v���n�u")]
    [SerializeField] private GameObject _audioPrefab;

    [Header("�Đ�����T�E���h�̃f�[�^")]
    [SerializeField] private Sounds _soundsData;

    [Header("���������I�u�W�F�N�g���폜���鎞��")]
    [SerializeField] private float _destroyIntereval = 2.0f;

    /// <summary>
    /// Audio���Đ����邽�߂̃v���n�u�̃v���p�e�B
    /// </summary>
    public GameObject AudioPrefab => _audioPrefab;

    /// <summary>
    /// �Đ�����T�E���h�̃f�[�^�̃v���n�u
    /// </summary>
    public Sounds SoundsData => _soundsData;

    /// <summary>
    /// ���������I�u�W�F�N�g���폜����܂ł̎��Ԃ̃v���p�e�B
    /// </summary>
    public float DestroyInterval => _destroyIntereval;
}