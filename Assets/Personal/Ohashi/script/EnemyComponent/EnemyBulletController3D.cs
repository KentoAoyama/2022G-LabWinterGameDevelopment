using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBulletController3D : RetainedEnemyBulletBehavior
{
    [SerializeField, Tooltip("�e�̃X�s�[�h")]
    private float _bulletSpeed = 2f;

    private Rigidbody _rb;
    private EnemyBulletId _enemyBulletId;
    private int _bulletId;
    private GameObject _player;
    private EnemyMove _enemyMove;

    public override int Id => _bulletId;

    public void Set(EnemyMove enemyMove)
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
    ///  �v���C���[�Ƃ̋����Œe���΂����������߁A��΂�
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
        //IAddDamage���p�����Ă���N���X�̃I�u�W�F�N�g�ɐڐG�����Ƃ��ȉ������s����
        if (other.TryGetComponent(out IAddDamage addDamage))
        {
            Debug.Log("�U������������(������)");
        }
    }
}
