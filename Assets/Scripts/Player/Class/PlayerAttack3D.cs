using System;
using UnityEngine;

[System.Serializable]
public class PlayerAttack3D : PlayerAttack
{
    public override void AttackProcess()
    {
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