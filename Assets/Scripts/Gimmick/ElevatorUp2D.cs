using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 上昇するエレベーター
/// </summary>
public class ElevatorUp2D : MonoBehaviour, ISwitchable
{
    [Tooltip("エレベーターに乗るのを遮断するCollider(LeverとElevatorの間にある)")]
    [SerializeField] private Collider2D _blockCollider;

    /// <summary> エレベーターが動くAnimation </summary>
    private Animator _anim;

    /// <summary> アクティブか、非アクティブか </summary>
    private bool _isActive;
    /// <summary> アクティブか、非アクティブか </summary>
    public bool IsActive => _isActive;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    //レバーを動かしたら、エレベーターに乗れるようになるもの(Colliderを消す等)
    public void Active()
    {
        _isActive = true;
        _blockCollider.enabled = false;
    }

    public void InActive()
    {
        _isActive = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("上昇します");
        col.gameObject.transform.SetParent(gameObject.transform);
        _anim.Play("ElevatorMove");
        SoundManager.Instance.AudioPlay(SoundType.SE, 0);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        col.gameObject.transform.parent = null;
    }
}
