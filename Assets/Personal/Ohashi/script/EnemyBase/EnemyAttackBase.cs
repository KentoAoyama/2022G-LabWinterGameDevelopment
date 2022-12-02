using UnityEngine;
using System.Threading.Tasks;

public abstract class EnemyAttackBase
{
    private const int MilliSecond = 1000;
    protected bool _isAttack = false;

    public bool IsAttack => _isAttack;

    /// <summary>
    /// エネミーの攻撃処理
    /// </summary>
    public abstract void EnemyAttack();
    /// <summary>
    /// エネミーの攻撃のインターバル
    /// </summary>
    protected async Task EnemyAttackInterval(int attackInterval)
    {
        _isAttack = true;
        Debug.Log("attack");
        //指定したミリ秒後に実行する
        await Task.Delay(MilliSecond * attackInterval);
        _isAttack = false;
    }
}
