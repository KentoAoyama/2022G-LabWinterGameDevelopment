using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, ISwitchable
{
    /// <summary> ドアが開くAnimation </summary>
    private Animator _anim;

    /// <summary> アクティブか、非アクティブか </summary>
    private bool _isActive;
    /// <summary> アクティブか、非アクティブか </summary>
    public bool IsActive => _isActive;
    // { get; } のみのプロパティは、上記のような書き方で出来る

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
