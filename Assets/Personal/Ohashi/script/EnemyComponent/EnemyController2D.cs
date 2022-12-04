using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController2D : RetainedEnemyBehavior, IAddDamage, IPause
{
    [SerializeField, Tooltip("�ړ�")]
    private EnemyMove2D _enemyMove = new EnemyMove2D();
    [SerializeField, Tooltip("�ߋ����U��")]
    private EnemyShortAttack2D _enemyShortAttack2D = new EnemyShortAttack2D();
    [SerializeField, Tooltip("�������U��")]
    private EnemyLongAttack _enemyLongAttack = new EnemyLongAttack();
    [SerializeField, Tooltip("�q�b�g�|�C���g���Ǘ����Ă���N���X")]
    private EnemyHealth _enemyHealth = new EnemyHealth();
    [SerializeField, Tooltip("�G�l�~�[�̃^�C�v")]
    private EnemyId _enemyId;
    [SerializeField, Tooltip("�|�[�Y�����ǂ���")]
    private bool _isPause = false;

    private Rigidbody2D _rb2D;
    private int _id;

    public override int Id => _id;

    public override int Health { get => _enemyHealth.Health; set => _enemyHealth.Health = value; }

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        //_enemyStateController.InIt(_enemyMove, _enemyLongAttack, _enemyHealth)
        _enemyMove.Set2D(_rb2D, transform, ObjectHolderManager.Instance.PlayerHolder);
        _enemyShortAttack2D.AttackSet(_enemyMove, _rb2D);
        _enemyLongAttack.LongAttackSet(_enemyMove);
        _id = (int)_enemyId;
    }

    private void Update()
    {
        if(!_isPause)
        {
            _enemyMove.Move();
            Attack();
        }
    }

    /// <summary>
    /// �^�C�v�ʂōU��������
    /// </summary>
    private void Attack()
    {
        if (_enemyId == EnemyId.Short)
        {
            _enemyShortAttack2D.EnemyAttack();
        }
        else if(_enemyMove.PlayerSearch(_enemyMove.AttackDistance) && !_enemyLongAttack.IsAttack)
        {
            _enemyLongAttack.EnemyAttack();
        }
    }

    void IAddDamage.AddDamage(int damage)
    {
        _enemyHealth.EnemyDamage(damage);
    }

    public void Pause()
    {
        _isPause = true;
    }

    public void Resume()
    {
        _isPause = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //IAddDamage���p�����Ă���N���X�̃I�u�W�F�N�g�ɐڐG�����Ƃ��ȉ������s����
        if (collision.TryGetComponent(out IAddDamage addDamage))
        {
            Debug.Log("�U������������");
        }
    }
}
