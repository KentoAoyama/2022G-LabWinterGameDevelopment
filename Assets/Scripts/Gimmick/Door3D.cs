using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3D : MonoBehaviour, ISwitchable
{
    /// <summary> �h�A���J��Animation </summary>
    private Animator _anim;

    private BoxCollider _collider;

    /// <summary> �A�N�e�B�u���A��A�N�e�B�u�� </summary>
    private bool _isActive;
    /// <summary> �A�N�e�B�u���A��A�N�e�B�u�� </summary>
    public bool IsActive => _isActive;
    // { get; } �݂̂̃v���p�e�B�́A��L�̂悤�ȏ������ŏo����

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider>();
    }

    public void Active()
    {
        _isActive = true;
        _anim.Play("Open");
        _collider.isTrigger = true;
        SoundManager.Instance.AudioPlay(SoundType.SE, 16);

        Debug.Log("Door");
    }

    public void InActive()
    {
        _isActive = false;
    }
}
