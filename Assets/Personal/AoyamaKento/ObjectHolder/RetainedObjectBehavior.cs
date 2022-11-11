using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ObjectHolder�ɕێ������GameObject�̃N���X�Ɍp�������钊�ۃN���X
/// </summary>
public class RetainedObjectBehavior : MonoBehaviour
{
    //ObjectHolderManager�Ɏ��g�̃C���X�^���X��o�^
    protected virtual void Awake()
    {
        ObjectHolderManager.Instance.ObjectHolder.Add(gameObject);
    }

    //ObjectHolderManager���玩�g�̃C���X�^���X���폜
    protected virtual void OnDestroy()
    {
        ObjectHolderManager.Instance.ObjectHolder.Remove(gameObject);
    }
}
