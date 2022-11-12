using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ObjectHolder�ɕێ������Object�̃N���X�Ɍp�������钊�ۃN���X
/// </summary>
public abstract class RetainedHolderBehavior : MonoBehaviour
{
    //ObjectHolderManager�Ɏ��g�̃C���X�^���X��o�^
    protected virtual void Awake()
    {
        ObjectHolderManager.Instance.AddHolder(gameObject);
    }

    //ObjectHolderManager���玩�g�̃C���X�^���X���폜
    public virtual void OnDisable()
    {
        ObjectHolderManager.Instance.RemoveHolder(gameObject);
    }
}
