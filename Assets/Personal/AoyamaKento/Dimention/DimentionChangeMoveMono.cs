using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviorを継承した値などを定義するクラス
/// </summary>
public class DimentionChangeMoveMono : MonoBehaviour
{  


    private void Start()
    {
        DimentionManager.Instance.ChangeMoveMono = this;
    }
}
