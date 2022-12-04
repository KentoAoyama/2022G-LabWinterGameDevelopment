using System;
using UnityEngine;

[System.Serializable]
public class PlayerAttack2D : PlayerAttack
{
    /// <summary> UŒ‚ˆ— </summary>
    public override void AttackProcess()
    {
        // UŒ‚‘ÎÛ‚ğæ“¾‚·‚é
        var pos = GetFirePos();

        var colliders = Physics2D.OverlapBoxAll(
            pos, _fireSize, 0.0f, _targetLayer);

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