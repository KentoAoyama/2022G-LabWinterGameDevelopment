using UnityEngine;
/// <summary>
/// 3Dでのエネミーの移動処理が書かれたクラス
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class EnemyMove3D : EnemyMove
{
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    protected override void RbMove()
    {
        Vector3 target = (_playerTransform.position - transform.position).normalized;
        _rb.velocity = new Vector3(target.x * _moveSpeed, 0, 0);
    }

}
