using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ObjectHolderに保持されるGameObjectのクラスに継承させる抽象クラス
/// </summary>
public class RetainedObjectBehavior : MonoBehaviour
{
    //ObjectHolderManagerに自身のインスタンスを登録
    protected virtual void Awake()
    {
        ObjectHolderManager.Instance.ObjectHolder.Add(gameObject);
    }

    //ObjectHolderManagerから自身のインスタンスを削除
    protected virtual void OnDestroy()
    {
        ObjectHolderManager.Instance.ObjectHolder.Remove(gameObject);
    }
}
