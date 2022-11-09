using UnityEngine;

public class EnemyHealth : MonoBehaviour, IEnemyAddDamage
{
    [SerializeField, Tooltip("�G�l�~�[�̃q�b�g�|�C���g(��)")] private int _enemyHealth = 2;

    public void EnemyAddDamage(int damage)
    {
        _enemyHealth -= damage;
        if(_enemyHealth < 1)
        {
            EnemyDestroy();
        }
    }
    /// <summary>
    /// �G�l�~�[�̃q�b�g�|�C���g��0�ȉ��ɂȂ������̏���
    /// </summary>
    private void EnemyDestroy()
    {
        Destroy(gameObject);//��
        //����A�j���[�V�������o�����肷��B
    }
}
