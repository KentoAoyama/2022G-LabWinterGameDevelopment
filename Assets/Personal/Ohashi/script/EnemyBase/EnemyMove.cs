using UnityEngine;
using UniRx;

public abstract class EnemyMove
{
    [SerializeField, Tooltip("移動するかどうかの距離")]
    protected float _moveDistance = 5.0f;
    [SerializeField, Tooltip("移動の速さ")]
    protected float _moveSpeed = 3.0f;
    [SerializeField, Tooltip("攻撃できるかどうかの距離")]
    private float _attackDistance = 3.0f;

    protected EnemyStateController _stateController;
    protected GameObject _player;
    protected GameObject _gameObject;
    private float _enemyDistansce;
    private const int RotationY = 180;
    private bool _isFinding = false;

    public bool IsFinding{ get => _isFinding; set => _isFinding = value; }
    public float AttackDistance => _attackDistance;
    public float EnemyDistance => _enemyDistansce;
    public float MoveDistansce => _moveDistance;

    private BoolReactiveProperty _isFind = new();

    /// <summary>
    /// ディメンション別のエネミーの移動処理
    /// </summary>
    protected abstract void MoveType();

    /// <summary>
    /// playerとenemyのX軸の二点間の差で距離を測る
    /// </summary>
    public bool PlayerSearch(float distance)
    {
        _enemyDistansce = _player.transform.position.x - _gameObject.transform.position.x;
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
            _gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            _gameObject.transform.rotation = new Quaternion(0, RotationY, 0, 0);
        }
    }

    /// <summary>
    /// アップデートでの使用クラス
    /// </summary>
    public void Move()
    {
        _isFind.Value = PlayerSearch(_moveDistance);
        Rotation();
        MoveType();
    }
    /// <summary>
    /// _isFindの値が変更されたときに呼ばれる
    /// </summary>
    public void FindPlayer()
    {
        _isFind
            .Where(x => x)
            .Subscribe(_ => _isFinding = true)
            .AddTo(_gameObject);
    }
}
