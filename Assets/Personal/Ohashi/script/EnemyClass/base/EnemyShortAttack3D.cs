using UnityEngine;
using System.Threading.Tasks;

[System.Serializable]
public class EnemyShortAttack3D
{
    [SerializeField, Tooltip("攻撃のインターバル")]
    private int _attackInterval = 3;

    private EnemyMove3D _enemyMove3D;
    private Rigidbody _rb;
    private bool _isAttack = false;

    private const int MilliSecond = 1000;

    public void AttackSet(EnemyMove3D enemyMove3D, Rigidbody rb)
    {
        _enemyMove3D = enemyMove3D;
        _rb = rb;
    }
    public void ShortAttack()
    {
        if(_enemyMove3D.PlayerSearch(_enemyMove3D.AttackDistance) && !_isAttack)
        {
            Task.Run(() => Test());
        }
    }
    private async Task Test()
    {
        _isAttack = true;
        Debug.Log("attack");
        //指定したミリ秒後に実行する
        await Task.Delay(MilliSecond * _attackInterval);
        _isAttack = false;
    }
}
