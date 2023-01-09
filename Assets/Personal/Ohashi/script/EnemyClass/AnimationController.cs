using UnityEngine;
/// <summary>
/// エネミーのアニメーション管理クラス
/// </summary>
[System.Serializable]
public class AnimationController
{
    private EnemyStateController _stateController;
    private Animator _anim;

    public void Init(EnemyStateController stateController, Animator anim)
    {
        _stateController = stateController;
        _anim = anim;
    }
    /// <summary>
    /// エネミーアニメーションの管理
    /// </summary>
    public void Animation()
    {
        FindAnimation();
        MoveAnimation();
        LongAttackAnimation();
        ShotAttackAnimation();
        DamageAnimation();
    }

    /// <summary>
    /// 移動のアニメーション管理
    /// </summary>
    private void MoveAnimation()
    {
        _anim.SetBool("IsMove",
            _stateController.EnemyState == EnemyState.Move ? true : false);
    }

    /// <summary>
    /// 遠距離攻撃のアニメーション管理
    /// </summary>
    private void LongAttackAnimation()
    {
        _anim.SetBool("IsLongAttack",
            _stateController.EnemyState == EnemyState.LongAttack ? true : false);
    }

    /// <summary>
    /// 近距離攻撃のアニメーション管理
    /// </summary>
    private void ShotAttackAnimation()
    {
        _anim.SetBool("IsShotAttack",
            _stateController.EnemyState == EnemyState.ShotAttack ? true : false);
    }

    /// <summary>
    /// 発見アニメーションの管理
    /// </summary>
    private void FindAnimation()
    {
        _anim.SetBool("IsFind",
            _stateController.EnemyState == EnemyState.Find ? true : false);
    }

    /// <summary>
    /// ダメージアニメーションの管理
    /// </summary>
    private void DamageAnimation()
    {
        if (_stateController.EnemyState == EnemyState.Damage)
        {
            _anim.Play("Damage");
        }
    }
}
