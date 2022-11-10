using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerAttack
{
    protected readonly PlayerStateController _state = default;
    protected readonly string _fireButtonName = default;
    protected readonly Transform _transform = default;
    protected readonly Vector3 _firePosOffset = default;
    protected readonly Vector3 _fireSize = default;
    protected readonly LayerMask _targetLayer = default;

    public PlayerAttack(
        PlayerStateController state,
        string fireButtonName, Transform transform,
        Vector3 firePosOffset, Vector3 fireSize, LayerMask targetLayer)
    {
        _state = state;
        _fireButtonName = fireButtonName;
        _transform = transform;
        _firePosOffset = firePosOffset;
        _fireSize = fireSize;
        _targetLayer = targetLayer;
    }

    public abstract void OnFire();

    protected Vector3 GetFirePos()
    {
        var pos = _firePosOffset;
        pos.x *= _state.FacingDirection == FacingDirection.RIGHT ? 1f : -1f;
        pos += _transform.position;

        return pos;
    }
}