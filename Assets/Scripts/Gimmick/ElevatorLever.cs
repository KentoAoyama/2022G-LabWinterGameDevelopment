using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLever : MonoBehaviour, IGimmickEvent
{
    [Tooltip("���̃��o�[�œ�����Gimmick")]
    [SerializeField] private Door client;

    [Tooltip("�v���C���[�̃A�j���[�V�������Đ����邩")]
    [SerializeField] private bool _isPlayAnimation;

    [Tooltip("")]
    [SerializeField] private GameObject _lever;

    public bool IsPlayAnimation => _isPlayAnimation;

    /// <summary>
    /// ���o�[�𓮂��������ɁAGimmick�ɑ΂��鑀������s����
    /// </summary>
    public void GimmickEvent()
    {
        //�I�u�W�F�N�g���A�N�e�B�u�Ȃ�
        if (!client.IsActive)
        {
            Debug.Log("OK");
            client.Active();
        }

        var transform = _lever.transform.localScale;
        transform.y = -_lever.transform.localScale.y;
        _lever.transform.localScale = transform;
    }
}
