using UnityEngine;
/// <summary>
/// 2Dでのエネミーの移動処理が書かれたクラス
/// </summary>
[System.Serializable]
public class EnemyMove2D : EnemyMove
{
    private Rigidbody2D _rb2D;

    public void InIt(Rigidbody2D rb2D, Transform enemyTransform,
        GameObject player, EnemyStateController stateController)
    {
        _rb2D = rb2D;
        _transform = enemyTransform;
        _player = player;
        _stateController = stateController;
    }

    protected override void RbMove()
    {
        if(_stateController.EnemyState == EnemyState.Move)
        {
            Vector2 target = (_player.transform.position - _transform.position).normalized;
            _rb2D.velocity = new Vector2(target.x * _moveSpeed, 0);
        }
    }
}
