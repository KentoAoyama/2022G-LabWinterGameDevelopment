using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.DIP
{
    public class Door : MonoBehaviour, ISwitchable
    {
        /// <summary> アクティブか、非アクティブか </summary>
        private bool _isActive;
        /// <summary> アクティブか、非アクティブか </summary>
        public bool IsActive => _isActive;

        public void Active()
        {
            _isActive = true;
            //Animation等の実際の処理を実行する
        }

        public void InActive()
        {
            _isActive = false;
        }
    }
}
