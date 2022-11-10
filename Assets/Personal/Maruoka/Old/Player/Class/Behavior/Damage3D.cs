using System;
using UnityEngine;
using UniRx;

[System.Serializable]
public class Damage3D : PlayerDamage
{
    // コンストラクタ
    public Damage3D(Rigidbody rb)
    {
        _rb = rb;
        Init();
    }

    private readonly Rigidbody _rb = default;
    private bool _isGodMode = true;

    private void Init()
    {
        PlayerStatusManager.Instance.Life.Skip(1).Subscribe(
            x => Debug.Log($"体力の変化を検知しました。現在の体力は{x}です。"));
    }

    public override void OnDamage(int value)
    {
        if (_isGodMode)
        {
            // ケントにノックバックするかどうか聞く
            // ノックバック処理
            // _rb.AddForce(dir * power, ForceMode.Impulse);
            // 体力を減らす
            PlayerStatusManager.Instance.Damage(value);
        }
    }
}