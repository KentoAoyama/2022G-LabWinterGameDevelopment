using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField, Tooltip("�v���C���[�̍��W")] private Transform _player;

    /// <summary>
    /// player��enemy��X���̓�_�Ԃ̍��ŋ����𑪂�
    /// </summary>
    private void PlayerSearch()
    {
        float player = _player.position.x - transform.position.x;
    }
}
