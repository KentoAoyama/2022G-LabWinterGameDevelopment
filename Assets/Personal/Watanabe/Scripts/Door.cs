using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, ISwitchable
{
    /// <summary> �h�A���J��Animation </summary>
    private Animator _anim;

    /// <summary> �A�N�e�B�u���A��A�N�e�B�u�� </summary>
    private bool _isActive;
    /// <summary> �A�N�e�B�u���A��A�N�e�B�u�� </summary>
    public bool IsActive => _isActive;
    // { get; } �݂̂̃v���p�e�B�́A��L�̂悤�ȏ������ŏo����

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Active()
    {
        _isActive = true;
        _anim.Play("Open");
    }

    public void InActive()
    {
        _isActive = false;
    }
}
