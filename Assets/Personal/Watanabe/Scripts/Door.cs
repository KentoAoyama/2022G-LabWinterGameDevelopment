using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.DIP
{
    public class Door : MonoBehaviour, ISwitchable
    {
        /// <summary> �A�N�e�B�u���A��A�N�e�B�u�� </summary>
        private bool _isActive;
        /// <summary> �A�N�e�B�u���A��A�N�e�B�u�� </summary>
        public bool IsActive => _isActive;

        public void Active()
        {
            _isActive = true;
            //Animation���̎��ۂ̏��������s����
        }

        public void InActive()
        {
            _isActive = false;
        }
    }
}
