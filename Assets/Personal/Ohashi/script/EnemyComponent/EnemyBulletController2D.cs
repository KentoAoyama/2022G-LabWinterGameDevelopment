using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBulletController2D : RetainedEnemyBulletBehavior
{
    [SerializeField, Tooltip("弾のスピード")]
    private float _bulletSpeed = 2f;
    [SerializeField]
    private int _bulletPower = 2;
    [SerializeField]
    private float _interval = 10f;

    private EnemyBulletId _enemyBulletId;
    private int _bulletId;
    private Rigidbody2D _rb2D;

    public override int Id => _bulletId;


    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _bulletId = (int)_enemyBulletId;
        BulletMove();
    }

    /// <summary>
    ///  プレイヤーとの距離で弾を飛ばす向きを決め、飛ばす
    /// </summary>
    private void BulletMove()
    {
        var test = ObjectHolderManager.Instance.PlayerHolder.transform.position.x -
      gameObject.transform.position.x;

        if (test < 0)
        {
            _rb2D.AddForce(-Vector3.right * _bulletSpeed, ForceMode2D.Impulse);
        }
        else
        {
            _rb2D.AddForce(Vector3.right * _bulletSpeed, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //IAddDamageを継承しているクラスのオブジェクトに接触したとき以下を実行する
        if (collision.TryGetComponent(out IAddDamage addDamage))
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
