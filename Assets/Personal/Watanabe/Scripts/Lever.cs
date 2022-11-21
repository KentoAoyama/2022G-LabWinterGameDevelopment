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
            //オブジェクトがアクティブなら
            if (!client.IsActive)
            {
                client.Active();
            }
        }
    }
}
