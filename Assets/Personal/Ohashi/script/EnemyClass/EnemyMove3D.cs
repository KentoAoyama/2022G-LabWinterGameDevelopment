using UnityEngine;

/// <summary>
/// 3D�ł̃G�l�~�[�̈ړ������������ꂽ�N���X�B
/// </summary>
[System.Serializable]
public class EnemyMove3D : EnemyMove
{
    private Rigidbody _rb;
    private EnemyStateController3D _enemyStateController;

    /// <summary>
    /// Rigidbody���Q�Ƃ��邽�߂̃��\�b�h
    /// </summary>
    public void Set3D(Rigidbody rb, Transform enemyTransform, 
        GameObject player, EnemyStateController3D enemyStateController)
    {
        _rb = rb;
        _enemyStateController = enemyStateController;
        _transform = enemyTransform;
        _player = player;
    }

    protected override void RbMove()
    {
        if(_enemyStateController.EnemyState == EnemyState.Move)
        {
            Vector3 target = (_player.transform.position - _transform.position).normalized;
            _rb.velocity = new Vector3(target.x * _moveSpeed, 0, 0);
        }
    }
}
