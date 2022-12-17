using UnityEngine;

/// <summary>
/// 3Dでのエネミーの移動処理が書かれたクラス。
/// </summary>
[System.Serializable]
public class EnemyMove3D : EnemyMove
{
    private Rigidbody _rb;

    public void InIt(Rigidbody rb, GameObject enemy, 
        GameObject player, EnemyStateController enemyStateController, 
        Animator anim)
    {
        _rb = rb;
        _stateController = enemyStateController;
        _gameObject = enemy;
        _player = player;
        _anim = anim;
    }

    protected override void MoveType()
    {
        if(_stateController.EnemyState == EnemyState.Move)
        {
            Vector3 target = (_player.transform.position - _gameObject.transform.position).normalized;
            _rb.velocity = new Vector3(target.x * _moveSpeed, 0, 0);
        }
    }
}
