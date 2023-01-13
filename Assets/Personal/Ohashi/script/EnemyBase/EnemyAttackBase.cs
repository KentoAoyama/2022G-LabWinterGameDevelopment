using UnityEngine;
using System.Threading.Tasks;

/// <summary>
/// エネミーの攻撃の基底クラス
/// </summary>
public abstract class EnemyAttackBase
{
    private const int MilliSecond = 1000;
    protected bool _isAttack = false;
    protected EnemyStateController _stateController;

    public bool IsAttack => _isAttack;

    /// <summary>
    /// エネミーの攻撃処理
    /// </summary>
    public abstract void EnemyAttack();
    /// <summary>
    /// 攻撃間のインターバル(UniTaskに変更する)
    /// </summary>
    protected async Task EnemyAttackInterval(int attackInterval)
    {
        _isAttack = true;
        
        //指定したミリ秒後に実行する
        await Task.Delay(MilliSecond * attackInterval);
        _isAttack = false;
    }
}
