using UnityEngine;
/// <summary>
/// 2Dでのエネミーの移動処理が書かれたクラス
/// </summary>
[System.Serializable]
public class EnemyMove2D : EnemyMove
{
    private Rigidbody2D _rb2D;

    protected override void RbMove()
    {
        Vector2 target = (_player.transform.position - _transform.position).normalized;
        _rb2D.velocity = new Vector2(target.x * _moveSpeed, 0);
    }

    public void Set2D(Rigidbody2D rb2D, Transform enemyTransform, GameObject player)
    {
        _rb2D = rb2D;
        _transform = enemyTransform;
        _player = player;
    }
}
