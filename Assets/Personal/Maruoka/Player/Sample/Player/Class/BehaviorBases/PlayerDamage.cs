using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public abstract class PlayerDamage
{
    public bool IsKnockBackNow => _isKnockBackNow;
    public bool IsGodMode => _isGodMode;

    [SerializeField]
    protected bool _isTest = false;
    [SerializeField]
    protected int _testDamageValue = 1;
    [SerializeField]
    protected Vector3 _testKnockBackDir = default;
    [SerializeField]
    protected float _testKnockBackPower = 1f;
    [SerializeField]
    protected int _testKnockBackTime = 1;


    [SerializeField]
    protected bool _isGodMode = false;
    private bool _isKnockBackNow = false;


    public virtual void OnDamage(int value,
        Vector3 knockBackDir, float knockBackPower,
        int knockBackTime)
    { 
    }

    // 指定秒ノックバック状態にする。（指定時間はﾐﾘsecond）
    // （ノックバック中はゴッドモードにする）
    protected async Task KnockBackStart(int sleepTime)
    {
        Debug.Log("ノックバック開始");
        _isKnockBackNow = true;
        _isGodMode = true;
        await Task.Run(() => Thread.Sleep(sleepTime));
        Debug.Log("ノックバック終了");
        _isKnockBackNow = false;
        _isGodMode = false;
    }
}