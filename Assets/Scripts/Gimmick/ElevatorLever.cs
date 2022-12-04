using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLever : MonoBehaviour, IGimmickEvent
{
    [Tooltip("このレバーで動かすGimmick")]
    [SerializeField] private Door client;

    [Tooltip("プレイヤーのアニメーションを再生するか")]
    [SerializeField] private bool _isPlayAnimation;

    [Tooltip("")]
    [SerializeField] private GameObject _lever;

    public bool IsPlayAnimation => _isPlayAnimation;

    /// <summary>
    /// レバーを動かした時に、Gimmickに対する操作を実行する
    /// </summary>
    public void GimmickEvent()
    {
        //オブジェクトがアクティブなら
        if (!client.IsActive)
        {
            Debug.Log("OK");
            client.Active();
        }

        var transform = _lever.transform.localScale;
        transform.y = -_lever.transform.localScale.y;
        _lever.transform.localScale = transform;
    }
}
