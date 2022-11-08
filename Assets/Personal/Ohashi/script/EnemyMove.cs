using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField, Tooltip("�v���C���[�̍��W")] private Transform _playerTransform;
    [SerializeField, Tooltip("�ړ����邩�ǂ����̋���")] private float _moveDistance = 5.0f;
    [SerializeField, Tooltip("�ړ��̑���")] private float _moveSpeed;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    /// <summary>
    /// player��enemy��X���̓�_�Ԃ̍��ŋ����𑪂�
    /// </summary>
    public bool PlayerSearch()
    {
        float playerDistans = _playerTransform.position.x - transform.position.x;
        if(_moveDistance > playerDistans && -_moveDistance < playerDistans)
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
        if(!PlayerSearch())
        {
            Vector3 target = (_playerTransform.position - transform.position).normalized;
            _rb.velocity = new Vector3(target.x * _moveSpeed, 0, 0);
        }
    }
}
