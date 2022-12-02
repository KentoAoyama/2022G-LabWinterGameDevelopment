using UnityEngine;

/// <summary>
/// 3D�ł̃G�l�~�[�̈ړ������������ꂽ�N���X�B
/// </summary>
[System.Serializable]
public class EnemyMove3D : EnemyMove
{
    private Rigidbody _rb;

    protected override void RbMove()
    {
        Vector3 target = (_player.transform.position - _transform.position).normalized;
        _rb.velocity = new Vector3(target.x * _moveSpeed, 0, 0);
    }

    /// <summary>
    /// Rigidbody���Q�Ƃ��邽�߂̃��\�b�h
    /// </summary>
    public void Set3D(Rigidbody rb)
    {
        _rb = rb;
    }
}
