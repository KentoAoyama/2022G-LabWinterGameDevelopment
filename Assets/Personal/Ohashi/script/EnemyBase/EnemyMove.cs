using UnityEngine;

public abstract class EnemyMove
{
    [SerializeField, Tooltip("�ړ����邩�ǂ����̋���")]
    protected float _moveDistance = 5.0f;
    [SerializeField, Tooltip("�ړ��̑���")]
    protected float _moveSpeed = 3.0f;
    [SerializeField, Tooltip("�U���ł��邩�ǂ����̋���")]
    private float _attackDistance = 3.0f;

    protected GameObject _player;
    protected Transform _transform;
    private float _enemyDistans;
    private const int RotationY = 180;

    public float AttackDistance => _attackDistance;
    public float EnemyDistans => _enemyDistans;

    /// <summary>
    /// �f�B�����V�����ʂ̃G�l�~�[�̈ړ�����
    /// </summary>
    protected abstract void RbMove();

    /// <summary>
    /// �Q�Ɨp���\�b�h
    /// </summary>
    public void SetBase(Transform enemyTransform, GameObject player)
    {
        _transform = enemyTransform;
        _player = player;
    }

    /// <summary>
    /// player��enemy��X���̓�_�Ԃ̍��ŋ����𑪂�
    /// </summary>
    public bool PlayerSearch(float distance)
    {
        _enemyDistans = _player.transform.position.x - _transform.position.x;
        if (distance > _enemyDistans)
        {
            if (-distance < _enemyDistans)
            {
                return true;
            }
        }
        return false;
    }

    private void Rotation()
    {
        if (_enemyDistans < 0)
        {
            _transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            _transform.rotation = new Quaternion(0, RotationY, 0, 0);
        }
    }

    /// <summary>
    /// �G�l�~�[�̈ړ�����
    /// </summary>
    public void Move()
    {
        Rotation();
        if (PlayerSearch(_moveDistance) && !PlayerSearch(_attackDistance))
        {
            RbMove();
        }
    }

}
