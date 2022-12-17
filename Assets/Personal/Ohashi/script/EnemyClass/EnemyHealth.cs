using UnityEngine;
using UniRx;

[System.Serializable]
public class EnemyHealth
{
    [SerializeField, Tooltip("ヒットポイント")]
    private int _maxHealth = 5;

    private IntReactiveProperty _health = new();
    private GameObject _enemy;
    private EnemyStateController _StateController;
    private bool _isDamage = false;
    private GameObject _enemyPrefab;

    public bool IsDamage { get => _isDamage; set => _isDamage = value; }
    public int Health { get => _health.Value; set => _health.Value = value; }

    public void Init(GameObject enemy, EnemyStateController stateController,
        GameObject enemyPrefab)
    {
        _enemy = enemy;
        _StateController = stateController;
        _enemyPrefab = enemyPrefab;
        _health.Value = _maxHealth;
        
    }
    /// <summary>
    /// ダメージ処理
    /// </summary>
    public void EnemyDamage(int damage)
    {
        _health.Value -= damage;
    }

    public void Damage()
    {
        _health
            .Skip(1)
            .Subscribe(_ => _isDamage = true)
            .AddTo(_enemy);
    }

    public void EnemyDestroy()
    {
        if (_StateController.EnemyState == EnemyState.Death)
        {
            Object.Instantiate(_enemyPrefab,
                _enemy.transform.position,
                _enemy.transform.rotation);
            Object.Destroy(_enemy);
        }
    }
}
