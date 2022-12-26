using UnityEngine;
/// <summary>
/// エネミーのアニメーションイベントのクラス
/// </summary>
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
    /// 遠距離攻撃のアニメーションイベント3D
    /// </summary>
    private void OnLongAttackEvent()
    {
        _enemyLongAttack.EnemyAttack();
    }
    /// <summary>
    /// 遠距離攻撃のアニメーションイベント2D
    /// </summary>
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
