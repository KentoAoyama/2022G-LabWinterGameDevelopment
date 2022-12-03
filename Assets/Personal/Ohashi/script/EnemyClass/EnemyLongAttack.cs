using UnityEngine;
using System.Threading.Tasks;

[System.Serializable]
public class EnemyLongAttack : EnemyAttackBase
{
    [SerializeField, Tooltip("�������U���̃C���^�[�o��")]
    private int _attackInterval = 3;
    [SerializeField, Tooltip("�o���b�g�𐶐�����I�u�W�F�N�g")]
    GameObject _muzzle;
    [SerializeField, Tooltip("�c�̃o���b�g")]
    private GameObject _verticalBullet;
    [SerializeField, Tooltip("���̃o���b�g")]
    private GameObject _horizontalBullet;

    private EnemyMove _enemyMove;
    private EnemyBulletId _enemyBulletId;

    public void LongAttackSet(EnemyMove enemyMove)
    {
        _enemyMove = enemyMove;
    }

    public override void EnemyAttack()
    {
        if (_enemyMove.PlayerSearch(_enemyMove.AttackDistance) && !_isAttack)
        {
            int random = Random.Range(0, System.Enum.GetNames(typeof(EnemyBulletId)).Length);
            _enemyBulletId = (EnemyBulletId)random;
            if (_enemyBulletId == EnemyBulletId.vertical)
            {
                Object.Instantiate(_verticalBullet, _muzzle.transform.position, _muzzle.transform.rotation);
            }
            else
            {
                Object.Instantiate(_horizontalBullet, _muzzle.transform.position, _muzzle.transform.rotation);
            }
            Task.Run(() => EnemyAttackInterval(_attackInterval));
        }
    }
}
