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
    private float _enemyDistansce;
    private const int RotationY = 180;

    public float AttackDistance => _attackDistance;
    public float EnemyDistance => _enemyDistansce;
    public float MoveDistansce => _moveDistance;

    /// <summary>
    /// �f�B�����V�����ʂ̃G�l�~�[�̈ړ�����
    /// </summary>
    protected abstract void RbMove();

    /// <summary>
    /// player��enemy��X���̓�_�Ԃ̍��ŋ����𑪂�
    /// </summary>
    public bool PlayerSearch(float distance)
    {
        _enemyDistansce = _player.transform.position.x - _transform.position.x;
        if (distance > _enemyDistansce)
        {
            if (-distance < _enemyDistansce)
            {
                return true;
            }
        }
        return false;
    }

    private void Rotation()
    {
        if (_enemyDistansce < 0)
        {
            _transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            _transform.rotation = new Quaternion(0, RotationY, 0, 0);
        }
    }

    /// <summary>
    /// �A�b�v�f�[�g�Ŏg�p�N���X
    /// </summary>
    public void Move()
    {
        Rotation();
        RbMove();
    }
}
