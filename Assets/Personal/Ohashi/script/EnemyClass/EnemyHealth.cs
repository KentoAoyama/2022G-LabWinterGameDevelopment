using UnityEngine;

[System.Serializable]
public class EnemyHealth
{
   [SerializeField, Tooltip("ヒットポイント")]
    private int _health;

    private GameObject _enemy;
    private EnemyStateController _StateController;

    public int Health { get => _health; set => _health = value; }

    public void Init(GameObject enemy, EnemyStateController stateController)
    {
        _enemy = enemy;
        _StateController = stateController;
    }
    /// <summary>
    /// ダメージ処理
    /// </summary>
    public void EnemyDamage(int damage)
    {
        _health -= damage;
        if (_StateController.EnemyState == EnemyState.Death)
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
        Object.Destroy(_enemy);
    }
}
