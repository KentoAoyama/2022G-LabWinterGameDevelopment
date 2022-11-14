using UnityEngine;

public abstract class EnemyMove
{
    [SerializeField, Tooltip("�ړ����邩�ǂ����̋���")] 
    protected float _moveDistance = 5.0f;
    [SerializeField, Tooltip("�ړ��̑���")]
    protected float _moveSpeed = 3.0f;
    [SerializeField, Tooltip("�U���ł��邩�ǂ����̋���")] 
    private float _attackDistance = 3.0f;

    protected Transform _playerTransform;
    protected Transform _transform = default;
    /// <summary>
    /// �f�B�����V�����ʂ̃G�l�~�[�̈ړ�����
    /// </summary>
    protected abstract void RbMove();

    /// <summary>
    /// �Q�Ɨp���\�b�h
    /// </summary>
    public void SetBase(Transform enemyTransform, Transform playerTransform)
    {
        _transform = enemyTransform;
        _playerTransform = playerTransform;
    }
    /// <summary>
    /// player��enemy��X���̓�_�Ԃ̍��ŋ����𑪂�
    /// </summary>
    public bool PlayerSearch(float distance)
    {
        float playerDistans = _playerTransform.position.x - _transform.position.x;
        //Debug.Log(playerDistans);
        if(distance > playerDistans && -distance < playerDistans)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// �G�l�~�[�̈ړ�����
    /// </summary>
    public void Move()
    {
        if(PlayerSearch(_moveDistance) && !PlayerSearch(_attackDistance))
        {
            RbMove();
        }
    }
}
