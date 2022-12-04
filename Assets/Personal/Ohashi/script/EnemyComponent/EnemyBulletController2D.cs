using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBulletController2D : RetainedEnemyBulletBehavior
{
    [SerializeField, Tooltip("�e�̃X�s�[�h")]
    private float _bulletSpeed;

    private EnemyBulletId _enemyBulletId;
    private int _bulletId;
    private Rigidbody2D _rb2D;

    public override int Id => _bulletId;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _bulletId = (int)_enemyBulletId;
    }

    /// <summary>
    ///  �v���C���[�Ƃ̋����Œe���΂����������߁A��΂�
    /// </summary>
    private void BulletMove()
    {
        float _distans = ObjectHolderManager.Instance.PlayerHolder.transform.position.x - transform.position.x;
        if (_distans < 0)
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
        //IAddDamage���p�����Ă���N���X�̃I�u�W�F�N�g�ɐڐG�����Ƃ��ȉ������s����
        if (collision.TryGetComponent(out IAddDamage addDamage))
        {
            Debug.Log("�U������������(������)");
        }
    }
}
