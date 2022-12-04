using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �㏸����G���x�[�^�[
/// </summary>
public class ElevatorUp2D : MonoBehaviour, ISwitchable
{
    [Tooltip("�G���x�[�^�[�ɏ��̂��Ւf����Collider(Lever��Elevator�̊Ԃɂ���)")]
    [SerializeField] private Collider2D _blockCollider;

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

    //���o�[�𓮂�������A�G���x�[�^�[�ɏ���悤�ɂȂ����(Collider��������)
    public void Active()
    {
        _isActive = true;
        _blockCollider.enabled = false;
    }

    public void InActive()
    {
        _isActive = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("�㏸���܂�");
        col.gameObject.transform.SetParent(gameObject.transform);
        _anim.Play("ElevatorMove");
        SoundManager.Instance.AudioPlay(SoundType.SE, 0);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        col.gameObject.transform.parent = null;
    }
}
