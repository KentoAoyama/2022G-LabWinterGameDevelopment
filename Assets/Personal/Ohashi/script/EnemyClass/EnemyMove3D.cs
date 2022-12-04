using UnityEngine;

/// <summary>
/// 3Dでのエネミーの移動処理が書かれたクラス。
/// </summary>
[System.Serializable]
public class EnemyMove3D : EnemyMove
{
    private Rigidbody _rb;

    /// <summary>
    /// Rigidbodyを参照するためのメソッド
    /// </summary>
    public void Set3D(Rigidbody rb, Transform enemyTransform, GameObject player)
    {
        _rb = rb;
        _transform = enemyTransform;
        _player = player;
    }

    protected override void RbMove()
    {
        Vector3 target = (_player.transform.position - _transform.position).normalized;
        _rb.velocity = new Vector3(target.x * _moveSpeed, 0, 0);
    }
}
