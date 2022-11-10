using System;
using UnityEngine;
using UniRx;

[System.Serializable]
public class Damage3D : PlayerDamage
{
    private Rigidbody _rb = default;

    public void Init(Rigidbody rb)
    {
        _rb = rb;

        // UniRx Test Code
        PlayerStatusManager.Instance.Life.Skip(1).Subscribe(
            x => Debug.Log($"体力の変化を検知しました。現在の体力は{x}です。"));
    }

    public override void OnDamage(int value)
    {
        if (_isGodMode)
        {
            // ノックバック処理
            // _rb.AddForce(dir * power, ForceMode.Impulse);
            // 体力を減らす
            PlayerStatusManager.Instance.Damage(value);
        }
    }
}