using UnityEngine;

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
    public void Animation()
    {
        FindAnimation();
        MoveAnimation();
        LongAttackAnimation();
        ShotAttackAnimation();
        DamageAnimation();
    }
    private void MoveAnimation()
    {
        _anim.SetBool("IsMove",
            _stateController.EnemyState == EnemyState.Move ? true : false);
    }
    private void LongAttackAnimation()
    {
        _anim.SetBool("IsLongAttack",
            _stateController.EnemyState == EnemyState.LongAttack ? true : false);
    }
    private void ShotAttackAnimation()
    {
        _anim.SetBool("IsShotAttack",
            _stateController.EnemyState == EnemyState.ShotAttack ? true : false);
    }
    private void FindAnimation()
    {
        _anim.SetBool("IsFind",
            _stateController.EnemyState == EnemyState.Find ? true : false);
    }
    private void DamageAnimation()
    {
        if (_stateController.EnemyState == EnemyState.Damage)
        {
            _anim.Play("Damage");
        }
    }
}
