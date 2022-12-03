using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBulletController3D : RetainedEnemyBulletBehavior
{
    [SerializeField, Tooltip("弾のスピード")]
    private float _bulletSpeed = 2f;

    private Rigidbody _rb;
    private EnemyBulletId _enemyBulletId;
    private int _bulletId;

    protected override int Id => _bulletId;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _bulletId = (int)_enemyBulletId;
        BulletMove();
    }

    /// <summary>
    ///  プレイヤーとの距離で弾を飛ばす向きを決め、飛ばす
    /// </summary>
    private void BulletMove()
    {
        float _distans = ObjectHolderManager.Instance.PlayerHolder.transform.position.x - transform.position.x;
        if (_distans < 0)
        {
            _rb.AddForce(-Vector3.right * _bulletSpeed, ForceMode.Impulse);
        }
        else
        {
            _rb.AddForce(Vector3.right * _bulletSpeed, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //IAddDamageを継承しているクラスのオブジェクトに接触したとき以下を実行する
        if (other.TryGetComponent(out IAddDamage addDamage))
        {
            Debug.Log("攻撃が当たった(遠距離)");
        }
    }
}
