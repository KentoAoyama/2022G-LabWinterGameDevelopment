using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerAttack
{
    protected PlayerStateController _stateController = default;
    protected Transform _transform = default;
    public bool _isAttackNow = false;

    [InputName, SerializeField]
    protected string _fireButtonName = default;
    [SerializeField]
    protected Vector3 _firePosOffset = default;
    [SerializeField]
    protected Vector3 _fireSize = default;
    [SerializeField]
    protected LayerMask _targetLayer = default;
    [SerializeField]
    protected bool _isDrawGizmo = false;
    [SerializeField]
    protected Color _gizmoColor = Color.red;

    public Vector3 FirePosOffset => _firePosOffset;
    public Vector3 FireSize => _fireSize;
    public Color GizmoColor => _gizmoColor;
    public bool IsDrawGizmo => _isDrawGizmo;
    public bool IsAttackNow => _isAttackNow;


    public void Init(Transform transform,
        PlayerStateController stateController)
    {
        _transform = transform;
        _stateController = stateController;
    }

    public abstract void Fire();

    public Vector3 GetFirePos()
    {
        var pos = _firePosOffset;

        pos.x *= _stateController.FacingDirection == FacingDirection.RIGHT ? 1f : -1f;

        pos += _transform.position;

        return pos;
    }
}