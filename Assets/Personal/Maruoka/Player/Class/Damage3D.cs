using System;
using UnityEngine;
using UniRx;
using System.Threading.Tasks;
using System.Threading;

[System.Serializable]
public class Damage3D : PlayerDamage
{

    private Rigidbody _rb = default;

    public void Init(Rigidbody rb)
    {
        _rb = rb;

        // UniRx Test Code
        // PlayerStatusManager.Instance.Life.Skip(1).Subscribe(
        //     x => Debug.Log($"体力の変化を検知しました。現在の体力は{x}です。"));
    }

    public override async void OnDamage(int value,
        Vector3 knockBackDir, float knockBackPower,
        int knockBackTime)
    {
        if (!_isGodMode)
        {
            if (_isTest)
            {
                value = _testDamageValue;
                knockBackDir = _testKnockBackDir;
                knockBackPower = _testKnockBackPower;
                knockBackTime = _testKnockBackTime;
            }            
            // ノックバック処理
            _rb.AddForce(knockBackDir.normalized * knockBackPower, ForceMode.Impulse);
            // 体力を減らす
            PlayerStatusManager.Instance.Damage(value);

            // ノックバック中、RigidBody Velocity の更新を止める
            await KnockBackStart(knockBackTime);
        }
    }
}