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
    protected Transform _transform;
    private float _enemyDistansce;
    private const int RotationY = 180;

    public float AttackDistance => _attackDistance;
    public float EnemyDistance => _enemyDistansce;
    public float MoveDistansce => _moveDistance;

    /// <summary>
    /// ディメンション別のエネミーの移動処理
    /// </summary>
    protected abstract void RbMove();

    /// <summary>
    /// playerとenemyのX軸の二点間の差で距離を測る
    /// </summary>
    public bool PlayerSearch(float distance)
    {
        _enemyDistansce = _player.transform.position.x - _transform.position.x;
        if (distance > _enemyDistansce)
        {
            if (-distance < _enemyDistansce)
            {
                return true;
            }
        }
        return false;
    }

    private void Rotation()
    {
        if (_enemyDistansce < 0)
        {
            _transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            _transform.rotation = new Quaternion(0, RotationY, 0, 0);
        }
    }

    /// <summary>
    /// アップデートで使用クラス
    /// </summary>
    public void Move()
    {
        Rotation();
        RbMove();
    }
}
