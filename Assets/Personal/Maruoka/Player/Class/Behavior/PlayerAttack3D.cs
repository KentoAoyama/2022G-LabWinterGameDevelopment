using System;
using UnityEngine;

[System.Serializable]
public class PlayerAttack3D : PlayerAttack
{
    public PlayerAttack3D(
        PlayerStateController state,
        string fireButtonName, Transform transform,
        Vector3 firePosOffset, Vector3 fireSize,
        LayerMask targetLayer) :
        base(state, fireButtonName, transform,
            firePosOffset, fireSize, targetLayer)
    {

    }

    public override void OnFire()
    {
        Debug.Log("3DUŒ‚‚ğÀs‚µ‚½");

        // UŒ‚‘ÎÛ‚ğæ“¾‚·‚é
        var pos = GetFirePos();

        var colliders = Physics.OverlapBox(
            pos, _fireSize, Quaternion.identity, _targetLayer);

        // UŒ‚ˆ—‚ğÀs‚·‚é
        foreach (var e in colliders)
        {
            Debug.Log($"\"{e.name}\"‚ÉUŒ‚‚µ‚½");
            // if(e.TryGetComponent(out EnemyController enemy))
            // {
            //     enemy.Damage();
            // }
        }
    }
}