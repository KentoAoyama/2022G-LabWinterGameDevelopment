using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController3D : RetainedEnemyBehavior, IAddDamage, IPause
{
    [SerializeField, Tooltip("�ړ�")]
    private EnemyMove3D _enemyMove = new();
    [SerializeField, Tooltip("�ߋ����U��")]
    private EnemyShortAttack3D _enemyShortAttack3D = new();
    [SerializeField, Tooltip("�������U��")]
    private EnemyLongAttack _enemyLongAttack = new();
    [SerializeField, Tooltip("�q�b�g�|�C���g���Ǘ����Ă���N���X")]
    private EnemyHealth _enemyHealth = new();
    [SerializeField, Tooltip("��ԊǗ�")]
    private EnemyStateController _stateController = new();
    [SerializeField, Tooltip("�G�l�~�[�̃^�C�v")]
    private EnemyId _enemyId;
    [SerializeField, Tooltip("�|�[�Y�����ǂ���")]
    private bool _isPause = false;

    private Rigidbody _rb;
    private int _id;

    public EnemyMove3D EnemyMove => _enemyMove;
    public override int Id => _id;

    public override int Health { get => _enemyHealth.Health; set => _enemyHealth.Health = value; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _stateController.InIt(EnemyMove, _enemyLongAttack, _enemyHealth,
            _enemyShortAttack3D, _enemyId);
        _enemyHealth.InIt(gameObject, _stateController);
        _enemyMove.InIt(_rb, transform,
            ObjectHolderManager.Instance.PlayerHolder, _stateController);
        _enemyShortAttack3D.InIt(_enemyMove, _rb, _stateController);
        _id = (int)_enemyId;
    }

    private void Update()
    {
        if(!_isPause)
        {
            _stateController.State();
            _enemyMove.Move();
            Attack();
        }
    }

    /// <summary>
    /// �^�C�v�ʂōU��������
    /// </summary>
    private void Attack()
    {
        if(_stateController.EnemyState == EnemyState.ShotAttack)
        {
            _enemyShortAttack3D.EnemyAttack();
        }
        else if(_stateController.EnemyState == EnemyState.LongAttack)
        {
            _enemyLongAttack.EnemyAttack();
            _enemyLongAttack.Bullet.GetComponent<EnemyBulletController3D>().Set(_enemyMove);
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

    private void OnTriggerEnter(Collider other)
    {
        //IAddDamage���p�����Ă���N���X�̃I�u�W�F�N�g�ɐڐG�����Ƃ��ȉ������s����
        if (other.TryGetComponent(out IAddDamage addDamage))
        {
            Debug.Log("�U������������");
        }
    }
}
