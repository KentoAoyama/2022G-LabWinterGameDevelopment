using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerHolder�ɕێ������Player�̃N���X�Ɍp�������钊�ۃN���X
/// </summary>
public class RetainedPlayerBehavior : MonoBehaviour
{
    //ObjectHolderManager�Ɏ��g�̃C���X�^���X��o�^
    protected virtual void Awake()
    {
        ObjectHolderManager.Instance.PlayerHolder = gameObject;
    }
}
