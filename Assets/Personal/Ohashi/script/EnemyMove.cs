using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤーの座標")] private Transform _playerTransform;
    [SerializeField, Tooltip("移動するかどうかの距離")] private float _moveDistance = 5.0f;
    [SerializeField, Tooltip("移動の速さ")] private float _moveSpeed;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    /// <summary>
    /// playerとenemyのX軸の二点間の差で距離を測る
    /// </summary>
    public bool PlayerSearch()
    {
        float playerDistans = _playerTransform.position.x - transform.position.x;
        if(_moveDistance > playerDistans && -_moveDistance < playerDistans)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// エネミーの移動処理
    /// </summary>
    public void Move()
    {
        if(!PlayerSearch())
        {
            Vector3 target = (_playerTransform.position - transform.position).normalized;
            _rb.velocity = new Vector3(target.x * _moveSpeed, 0, 0);
        }
    }
}
