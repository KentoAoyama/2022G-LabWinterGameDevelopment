using System;
using UnityEngine;

[System.Serializable]
public class PlayerAttack2D : PlayerAttack
{
    public PlayerAttack2D(
        PlayerStateController state,
        string fireButtonName, Transform transform,
        Vector3 firePosOffset, Vector3 fireSize,
        LayerMask targetLayer) :
        base(state, fireButtonName, transform,
            firePosOffset, fireSize, targetLayer)
    { }

    public override void OnFire()
    {
        // Debug.Log("2D�U�������s����");

        // �U���Ώۂ��擾����
        var pos = GetFirePos();

        var colliders = Physics2D.OverlapBoxAll(
            pos, _fireSize, 0.0f, _targetLayer);

        // �U�����������s����
        foreach (var e in colliders)
        {
            Debug.Log($"\"{e.name}\"�ɍU������");
            // if(e.TryGetComponent(out EnemyController enemy))
            // {
            //     enemy.Damage();
            // }
        }
    }
}