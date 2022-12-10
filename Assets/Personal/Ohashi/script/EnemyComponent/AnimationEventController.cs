using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationEventController : MonoBehaviour
{
    private EnemyMove _enemyMove;
    private EnemyLongAttack _enemyLongAttack;

    public void Init(EnemyMove enemyMove, EnemyLongAttack enemyLongAttack)
    {
        _enemyMove = enemyMove;
        _enemyLongAttack = enemyLongAttack;
    }

    private void OnLongAttackEvent()
    {
        _enemyLongAttack.EnemyAttack();
        _enemyLongAttack.Bullet.GetComponent<EnemyBulletController3D>().Set(_enemyMove);
    }
}
