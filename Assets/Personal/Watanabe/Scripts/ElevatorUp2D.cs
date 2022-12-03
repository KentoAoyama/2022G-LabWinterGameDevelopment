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

    public void Active()
    {
        _isActive = true;
        _blockCollider.enabled = false;
    }

    public void InActive()
    {
        _isActive = false;
    }

    //���o�[�𓮂�������A�G���x�[�^�[�ɏ���悤�ɂȂ����(Collider��������)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�㏸���܂�");
        collision.gameObject.transform.SetParent(gameObject.transform);
        _anim.Play("ElevatorMove");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.transform.parent = null;
    }
}
