using UnityEngine;

[System.Serializable]
public class EnemyHealth
{
   [SerializeField, Tooltip("�q�b�g�|�C���g")]
    private int _health;

    private GameObject _gameObject;
    private EnemyStateController _StateController;

    public int Health { get => _health; set => _health = value; }

    public void Init(GameObject enemy, EnemyStateController stateController)
    {
        _gameObject = enemy;
        _StateController = stateController;
    }
    /// <summary>
    /// �_���[�W����
    /// </summary>
    public void EnemyDamage(int damage)
    {
        _health -= damage;
        if (_StateController.EnemyState == EnemyState.Death)
        {
            EnemyDestroy();
        }
    }

    /// <summary>
    /// �G�l�~�[�̃q�b�g�|�C���g��0�ȉ��ɂȂ������̏���
    /// </summary>
    private void EnemyDestroy()
    {
        //����A�j���[�V�������o�����肷��B
        Object.Destroy(_gameObject);
    }
}
