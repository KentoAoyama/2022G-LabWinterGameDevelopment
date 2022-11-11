using UnityEngine;
/// <summary>
/// 2D�ł̃G�l�~�[�̈ړ������������ꂽ�N���X
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove2D : EnemyMove
{
    private Rigidbody2D _rb2D;

    protected override void RbMove()
    {
        Vector3 target = (_playerTransform.position - _transform.position).normalized;
        _rb2D.velocity = new Vector3(target.x * _moveSpeed, 0, 0);
    }

}
