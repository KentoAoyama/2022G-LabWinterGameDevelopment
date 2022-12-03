using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [Tooltip("このレバーで動かすGimmick")]
    [SerializeField] private ISwitchable client;

    /// <summary>
    /// レバーを動かした時に、Gimmickに対する操作を実行する
    /// </summary>
    public void ActiveCheck()
    {
        //オブジェクトがアクティブなら
        if (!client.IsActive)
        {
            client.Active();
        }
    }
}
