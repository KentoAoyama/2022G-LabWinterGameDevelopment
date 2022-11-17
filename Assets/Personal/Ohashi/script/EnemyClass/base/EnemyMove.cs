using UnityEngine;

public abstract class EnemyMove
{
    [SerializeField, Tooltip("移動するかどうかの距離")] 
    protected float _moveDistance = 5.0f;
    [SerializeField, Tooltip("移動の速さ")]
    protected float _moveSpeed = 3.0f;
    [SerializeField, Tooltip("攻撃できるかどうかの距離")] 
    private float _attackDistance = 3.0f;

    protected GameObject _player;
    protected Transform _transform = default;

    public float AttackDistance => _attackDistance;
    /// <summary>
    /// ディメンション別のエネミーの移動処理
    /// </summary>
    protected abstract void RbMove();

    /// <summary>
    /// 参照用メソッド
    /// </summary>
    public void SetBase(Transform enemyTransform, GameObject player)
    {
        _transform = enemyTransform;
        _player = player;
    }
    /// <summary>
    /// playerとenemyのX軸の二点間の差で距離を測る
    /// </summary>
    public bool PlayerSearch(float distance)
    {
        float playerDistans = _player.transform.position.x - _transform.position.x;
        //Debug.Log(playerDistans);
        if(distance > playerDistans && -distance < playerDistans)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// エネミーの移動判定
    /// </summary>
    public void Move()
    {
        if(PlayerSearch(_moveDistance) && !PlayerSearch(_attackDistance))
        {
            RbMove();
        }
    }
}
