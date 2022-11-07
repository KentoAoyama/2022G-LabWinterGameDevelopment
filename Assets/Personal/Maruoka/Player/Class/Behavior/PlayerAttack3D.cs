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
        Debug.Log("3D�U�������s����");

        // �U���Ώۂ��擾����
        var pos = GetFirePos();

        var colliders = Physics.OverlapBox(
            pos, _fireSize, Quaternion.identity, _targetLayer);

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