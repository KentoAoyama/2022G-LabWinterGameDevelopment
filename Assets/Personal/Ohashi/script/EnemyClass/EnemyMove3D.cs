using UnityEngine;

/// <summary>
/// 3Dでのエネミーの移動処理が書かれたクラス。
/// </summary>
[System.Serializable]
public class EnemyMove3D : EnemyMove
{
    private Rigidbody _rb;

    protected override void RbMove()
    {
        Vector3 target = (_player.transform.position - _transform.position).normalized;
        _rb.velocity = new Vector3(target.x * _moveSpeed, 0, 0);
    }

    /// <summary>
    /// Rigidbodyを参照するためのメソッド
    /// </summary>
    public void Set3D(Rigidbody rb)
    {
        _rb = rb;
    }
}
