using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationEventController : MonoBehaviour
{
    private EnemyMove _enemyMove;
    private EnemyLongAttack _enemyLongAttack;
    private EnemyAttackBase _enemyShotAttack;

    public void Init(EnemyMove enemyMove, EnemyLongAttack enemyLongAttack,
        EnemyAttackBase enemyShotAttack)
    {
        _enemyMove = enemyMove;
        _enemyLongAttack = enemyLongAttack;
        _enemyShotAttack = enemyShotAttack;
    }
    /// <summary>
    /// 遠距離攻撃のアニメーションイベント
    /// </summary>
    private void OnLongAttackEvent()
    {
        _enemyLongAttack.EnemyAttack();
    }
    private void OnLongAttackEvent2D()
    {
        _enemyLongAttack.EnemyAttack();
    }
    //近距離攻撃のアニメーションイベント
    private void OnShotAttackEvent()
    {
        _enemyShotAttack.EnemyAttack();
    }
}
