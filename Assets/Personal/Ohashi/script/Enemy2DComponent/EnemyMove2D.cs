using UnityEngine;
/// <summary>
/// 2Dでのエネミーの移動処理が書かれたクラス
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove2D : EnemyMove
{
    private Rigidbody2D _rb2D;

    protected override void RbMove()
    {
        Vector3 target = (_playerTransform.position - _transform.position).normalized;
        _rb2D.velocity = new Vector3(target.x * _moveSpeed, 0, 0);
    }

}
