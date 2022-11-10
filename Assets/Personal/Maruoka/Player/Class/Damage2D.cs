using System;
using UnityEngine;

[System.Serializable]
public class Damage2D : PlayerDamage
{
    private Rigidbody2D _rb2D = default;

    public void Init(Rigidbody2D rb2D)
    {
        _rb2D = rb2D;
    }

    public override void OnDamage(int value)
    {
        // 体力を減らす処理を記述する

        // ノックバック処理を記述する
    }
}