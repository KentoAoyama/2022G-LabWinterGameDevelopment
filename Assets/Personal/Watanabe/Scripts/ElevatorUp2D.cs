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

    public void Active()
    {
        _isActive = true;
        _blockCollider.enabled = false;
    }

    public void InActive()
    {
        _isActive = false;
    }

    //レバーを動かしたら、エレベーターに乗れるようになるもの(Colliderを消す等)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("上昇します");
        collision.gameObject.transform.SetParent(gameObject.transform);
        _anim.Play("ElevatorMove");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.transform.parent = null;
    }
}
