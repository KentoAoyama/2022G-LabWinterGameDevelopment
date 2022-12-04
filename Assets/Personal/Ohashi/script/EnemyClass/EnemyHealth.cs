using UnityEngine;

[System.Serializable]
public class EnemyHealth
{
   [SerializeField, Tooltip("�q�b�g�|�C���g")]
    private int health;

    public int Health { get => health; set => health = value; }

    /// <summary>
    /// �_���[�W����
    /// </summary>
    public void EnemyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
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
    }
}
