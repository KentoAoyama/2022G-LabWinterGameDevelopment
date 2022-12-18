using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour, ISwitchable
{
    /// <summary> �G���x�[�^�[������Animation </summary>
    private Animator _anim;

    /// <summary> �A�N�e�B�u���A��A�N�e�B�u�� </summary>
    private bool _isActive;
    /// <summary> �A�N�e�B�u���A��A�N�e�B�u�� </summary>
    public bool IsActive => _isActive;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Active()
    {
        _isActive = true;
        //_anim.Play("ElevatorMove");
        //SoundManager.Instance.AudioPlay(SoundType.SE, 0);
    }

    public void InActive()
    {
        _isActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�㏸���܂�");
        _anim.Play("ElevatorMove");
        SoundManager.Instance.AudioPlay(SoundType.SE, 0);
    }
}
