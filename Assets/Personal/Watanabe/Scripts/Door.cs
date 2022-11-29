using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, ISwitchable
{
    [Tooltip("�h�A���J��Animation")]
    [SerializeField] private Animation _anim;

    /// <summary> �A�N�e�B�u���A��A�N�e�B�u�� </summary>
    private bool _isActive;
    /// <summary> �A�N�e�B�u���A��A�N�e�B�u�� </summary>
    public bool IsActive => _isActive;

    public void Active()
    {
        _isActive = true;
        //Animation���̎��ۂ̏��������s����
        _anim.Play();
    }

    public void InActive()
    {
        _isActive = false;
    }
}
