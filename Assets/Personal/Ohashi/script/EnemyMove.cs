using UnityEngine;

public abstract class EnemyMove
{
    [SerializeField, Tooltip("プレイヤーの座標")] protected Transform _playerTransform;
    [SerializeField, Tooltip("移動するかどうかの距離")] protected float _moveDistance = 5.0f;
    [SerializeField, Tooltip("移動の速さ")] protected float _moveSpeed = 3.0f;
    [SerializeField, Tooltip("攻撃できるかどうかの距離")] private float _attackDistance;

    protected Transform _transform;

    /// <summary>
    /// ディメンション別のエネミーの移動処理
    /// </summary>
    protected abstract void RbMove();

    /// <summary>
    /// playerとenemyのX軸の二点間の差で距離を測る
    /// </summary>
    public bool PlayerSearch(float distance)
    {
        float playerDistans = _playerTransform.position.x - _transform.position.x;
        Debug.Log(playerDistans);
        if(distance > playerDistans && -distance < playerDistans)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// エネミーの移動判定
    /// </summary>
    public void Move(Rigidbody rb, Rigidbody2D rb2D)
    {
        if(PlayerSearch(_moveDistance) && !PlayerSearch(_attackDistance))
        {
            RbMove();
        }
    }
}
