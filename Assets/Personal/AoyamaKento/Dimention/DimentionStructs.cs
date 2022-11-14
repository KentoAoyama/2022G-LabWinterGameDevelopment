using UnityEngine;

/// <summary>
/// DimentionChange���ɏo���v���n�u�̍\����
/// </summary>
[System.Serializable]
public struct DimentionPrefabs
{
    public GameObject Player;
    public GameObject[] Enemy;
    public GameObject[] EnemyBullet;
}

/// <summary>
/// �G�̃X�e�[�^�X�̍\����
/// </summary>
public struct EnemyStatus
{
    public int Id;
    public int Health;
    public Transform Position;
}

/// <summary>
/// �G�̒e�̏��̍\����
/// </summary>
public struct EnemyBulletStatus
{
    public int Id;
    public Transform Position;
}