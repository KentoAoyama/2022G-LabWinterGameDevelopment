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
    public void InIt(Rigidbody rb, Transform enemyTransform, 
        GameObject player, EnemyStateController enemyStateController)
    {
        _rb = rb;
        _stateController = enemyStateController;
        _transform = enemyTransform;
        _player = player;
    }

    protected override void RbMove()
    {
        if(_stateController.EnemyState == EnemyState.Move)
        {
            Vector3 target = (_player.transform.position - _transform.position).normalized;
            _rb.velocity = new Vector3(target.x * _moveSpeed, 0, 0);
        }
    }
}
