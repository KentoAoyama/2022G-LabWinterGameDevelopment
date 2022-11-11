using UnityEngine;

public abstract class EnemyMove
{
    [SerializeField, Tooltip("�v���C���[�̍��W")] protected Transform _playerTransform;
    [SerializeField, Tooltip("�ړ����邩�ǂ����̋���")] protected float _moveDistance = 5.0f;
    [SerializeField, Tooltip("�ړ��̑���")] protected float _moveSpeed = 3.0f;
    [SerializeField, Tooltip("�U���ł��邩�ǂ����̋���")] private float _attackDistance;

    protected Transform _transform;

    /// <summary>
    /// �f�B�����V�����ʂ̃G�l�~�[�̈ړ�����
    /// </summary>
    protected abstract void RbMove();

    /// <summary>
    /// player��enemy��X���̓�_�Ԃ̍��ŋ����𑪂�
    /// </summary>
    public bool PlayerSearch(float distance)
    {
        float playerDistans = _playerTransform.position.x - _transform.position.x;
        Debug.Log(playerDistans);
        if(distance > playerDistans && -distance < playerDistans)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// �G�l�~�[�̈ړ�����
    /// </summary>
    public void Move(Rigidbody rb, Rigidbody2D rb2D)
    {
        if(PlayerSearch(_moveDistance) && !PlayerSearch(_attackDistance))
        {
            RbMove();
        }
    }
}
