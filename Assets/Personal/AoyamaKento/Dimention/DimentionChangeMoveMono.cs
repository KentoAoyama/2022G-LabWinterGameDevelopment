using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehavior���p�������l�Ȃǂ��`����N���X
/// </summary>
public class DimentionChangeMoveMono : MonoBehaviour
{  


    private void Start()
    {
        DimentionManager.Instance.ChangeMoveMono = this;
    }
}
