using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [Tooltip("���̃��o�[�œ�����Gimmick")]
    [SerializeField] private ISwitchable client;

    /// <summary>
    /// ���o�[�𓮂��������ɁAGimmick�ɑ΂��鑀������s����
    /// </summary>
    public void ActiveCheck()
    {
        //�I�u�W�F�N�g���A�N�e�B�u�Ȃ�
        if (!client.IsActive)
        {
            client.Active();
        }
    }
}
