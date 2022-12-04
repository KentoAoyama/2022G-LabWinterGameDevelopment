using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerHolderに保持されるPlayerのクラスに継承させる抽象クラス
/// </summary>
public class RetainedPlayerBehavior : MonoBehaviour
{
    //ObjectHolderManagerに自身のインスタンスを登録
    protected virtual void Awake()
    {
        ObjectHolderManager.Instance.PlayerHolder = gameObject;
    }
}
