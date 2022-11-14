using UnityEngine;

/// <summary>
/// DimentionChange時に出すプレハブの構造体
/// </summary>
[System.Serializable]
public struct DimentionPrefabs
{
    public GameObject Player;
    public GameObject[] Enemy;
    public GameObject[] EnemyBullet;
}

/// <summary>
/// 敵のステータスの構造体
/// </summary>
public struct EnemyStatus
{
    public int Id;
    public int Health;
    public Transform Position;
}

/// <summary>
/// 敵の弾の情報の構造体
/// </summary>
public struct EnemyBulletStatus
{
    public int Id;
    public Transform Position;
}