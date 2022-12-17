using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBulletController3D : RetainedEnemyBulletBehavior
{
    [SerializeField, Tooltip("弾のスピード")]
    private float _bulletSpeed = 2f;
    [SerializeField]
    private int _bulletPower = 2;
    [SerializeField]
    private float _interval = 10f;

    private Rigidbody _rb;
    private EnemyBulletId _enemyBulletId;
    private int _bulletId;
    private EnemyMove _enemyMove;

    public override int Id => _bulletId;

    public void Init(EnemyMove enemyMove)
    {
        _enemyMove = enemyMove;
    }

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
        if (_enemyMove.EnemyDistance < 0)
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
            addDamage.AddDamage(_bulletPower);
            Debug.Log("攻撃が当たった(遠距離)");
        }
        Destroy(gameObject);
        StartCoroutine(DestroyInterval());
    }
    private IEnumerator DestroyInterval()
    {
        yield return new WaitForSeconds(_interval);
        Destroy(gameObject);
    }
}
