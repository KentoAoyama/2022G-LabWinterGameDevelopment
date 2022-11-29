using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, ISwitchable
{
    [Tooltip("ドアが開くAnimation")]
    [SerializeField] private Animation _anim;

    /// <summary> アクティブか、非アクティブか </summary>
    private bool _isActive;
    /// <summary> アクティブか、非アクティブか </summary>
    public bool IsActive => _isActive;

    public void Active()
    {
        _isActive = true;
        //Animation等の実際の処理を実行する
        _anim.Play();
    }

    public void InActive()
    {
        _isActive = false;
    }
}
