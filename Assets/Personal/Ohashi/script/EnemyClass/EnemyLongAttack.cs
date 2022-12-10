using UnityEngine;
using System.Threading.Tasks;

[System.Serializable]
public class EnemyLongAttack : EnemyAttackBase
{
    [SerializeField, Tooltip("遠距離攻撃のインターバル")]
    private int _attackInterval = 3;
    [SerializeField, Tooltip("バレットを生成するオブジェクト")]
    GameObject _muzzle;
    [SerializeField, Tooltip("縦のバレット")]
    private GameObject _verticalBullet;
    [SerializeField, Tooltip("横のバレット")]
    private GameObject _horizontalBullet;

    private EnemyBulletId _enemyBulletId;
    private GameObject _bullet;

    public GameObject Bullet => _bullet;

    public override void EnemyAttack()
    {
        int random = Random.Range(0, System.Enum.GetNames(typeof(EnemyBulletId)).Length);
        _enemyBulletId = (EnemyBulletId)random;
        if (_enemyBulletId == EnemyBulletId.vertical)
        {
            _bullet = Object.Instantiate(_verticalBullet, _muzzle.transform.position, _muzzle.transform.rotation);
        }
        else
        {
            _bullet = Object.Instantiate(_horizontalBullet, _muzzle.transform.position, _muzzle.transform.rotation);
        }
        Task.Run(() => EnemyAttackInterval(_attackInterval));
    }
}
