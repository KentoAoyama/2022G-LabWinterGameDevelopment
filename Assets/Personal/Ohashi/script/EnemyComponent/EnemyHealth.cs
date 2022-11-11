using UnityEngine;

public class EnemyHealth : MonoBehaviour, IEnemyAddDamage
{
    [SerializeField, Tooltip("エネミーのヒットポイント(仮)")] private int _enemyHealth = 2;

    public void EnemyAddDamage(int damage)
    {
        _enemyHealth -= damage;
        if(_enemyHealth < 1)
        {
            EnemyDestroy();
        }
    }
    /// <summary>
    /// エネミーのヒットポイントが0以下になった時の処理
    /// </summary>
    private void EnemyDestroy()
    {
        Destroy(gameObject);//仮
        //やられアニメーションを出したりする。
    }
}
