using UnityEngine;

[System.Serializable]
public class EnemyHealth
{
   [SerializeField, Tooltip("ヒットポイント")]
    private int health;

    public int Health { get => health; set => health = value; }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    public void EnemyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            EnemyDestroy();
        }
    }

    /// <summary>
    /// エネミーのヒットポイントが0以下になった時の処理
    /// </summary>
    private void EnemyDestroy()
    {
        //やられアニメーションを出したりする。
    }
}
