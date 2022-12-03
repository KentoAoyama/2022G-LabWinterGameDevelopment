using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour, ISwitchable
{
    /// <summary> エレベーターが動くAnimation </summary>
    private Animator _anim;

    /// <summary> アクティブか、非アクティブか </summary>
    private bool _isActive;
    /// <summary> アクティブか、非アクティブか </summary>
    public bool IsActive => _isActive;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Active()
    {
        _isActive = true;
        _anim.Play("ElevatorMove");
    }

    public void InActive()
    {
        _isActive = false;
    }
}
