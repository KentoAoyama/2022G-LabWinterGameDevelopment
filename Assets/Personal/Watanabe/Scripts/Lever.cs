using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.DIP
{
    public class Lever : MonoBehaviour
    {
        [SerializeField] private ISwitchable client;

        public void ActiveCheck()
        {
            //�I�u�W�F�N�g���A�N�e�B�u�Ȃ�
            if (!client.IsActive)
            {
                client.Active();
            }
        }
    }
}
