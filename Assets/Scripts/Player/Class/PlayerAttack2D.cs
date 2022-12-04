using System;
using UnityEngine;

[System.Serializable]
public class PlayerAttack2D : PlayerAttack
{
    /// <summary> �U������ </summary>
    public override void AttackProcess()
    {
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