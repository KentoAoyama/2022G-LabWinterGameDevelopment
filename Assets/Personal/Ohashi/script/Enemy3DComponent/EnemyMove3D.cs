using UnityEngine;
/// <summary>
/// 3D�ł̃G�l�~�[�̈ړ������������ꂽ�N���X�B
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class EnemyMove3D : EnemyMove
{
    private Rigidbody _rb;

    protected override void RbMove()
    {
        Vector3 target = (_playerTransform.position - _transform.position).normalized;
        _rb.velocity = new Vector3(target.x * _moveSpeed, 0, 0);
    }

}
