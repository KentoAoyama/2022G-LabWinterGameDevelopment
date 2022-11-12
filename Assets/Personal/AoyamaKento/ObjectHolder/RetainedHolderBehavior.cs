using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ObjectHolderに保持されるObjectのクラスに継承させる抽象クラス
/// </summary>
public abstract class RetainedHolderBehavior : MonoBehaviour
{
    //ObjectHolderManagerに自身のインスタンスを登録
    protected virtual void Awake()
    {
        ObjectHolderManager.Instance.AddHolder(gameObject);
    }

    //ObjectHolderManagerから自身のインスタンスを削除
    public virtual void OnDisable()
    {
        ObjectHolderManager.Instance.RemoveHolder(gameObject);
    }
}
