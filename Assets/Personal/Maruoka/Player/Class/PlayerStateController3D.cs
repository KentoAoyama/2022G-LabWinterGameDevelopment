using UnityEngine;

[System.Serializable]
public class PlayerStateController3D : PlayerStateController
{
    private Rigidbody _rb = default;
    private PlayerMove3D _playerMove3D = default;
    private GroundCheck _groundCheck = default;
    private PlayerAttack3D _playerAttack3D = default;
    private PlayerAction _playerAction = default;
    private Damage3D _damage3D = default;

    public void Init(Rigidbody rb, PlayerMove3D playerMove3D,
        GroundCheck groundCheck, PlayerAttack3D playerAttack3D,
        PlayerAction playerAction, Damage3D damage3D)
    {
        _rb = rb;
        _playerMove3D = playerMove3D;
        _groundCheck = groundCheck;
        _playerAttack3D = playerAttack3D;
        _playerAction = playerAction;
        _damage3D = damage3D;
    }
    public override void Update()
    {
        FacingDirectionUpdate();
        StateUpdate();
    }
    private void FacingDirectionUpdate()
    {
        // 向いている方向を更新する
        if (!Mathf.Approximately(_rb.velocity.x, 0f))
        {
            if (_rb.velocity.x > 0f)
            {
                FacingDirection = FacingDirection.RIGHT;
            }
            else if (_rb.velocity.x < 0f)
            {
                FacingDirection = FacingDirection.LEFT;
            }
        }
    }
    private void StateUpdate()
    {
        // ここにステートを更新する処理を記述する
    }

    private void StateUpdateMove()
    {
        if (!Mathf.Approximately(_rb.velocity.x, 0f))
        {
            _nowState = PlayerState.MOVE;
        }
    }
    private void StateUpdateStep()
    {
        if (_playerMove3D.IsStepNow)
        {
            _nowState = PlayerState.STEP_3D;
        }
    }
    private void StateUpdateRise()
    {
        // 接地しておらず、上昇中であれば、
        // 上昇ステートに変更する。
        if (!_groundCheck.IsGround() &&
             _rb.velocity.y > 0.01f)
        {
            _nowState = PlayerState.RISE;
        }
    }
    private void StateUpdateFall()
    {
        // 接地しておらず、落下であれば、
        // 落下ステートに変更する。
        if (!_groundCheck.IsGround() &&
             _rb.velocity.y < 0.01f)
        {
            _nowState = PlayerState.FALL;
        }
    }
    private void StateUpdateAttack()
    {
        // 未解決 : IsAttackNowの変更/更新
        if (_playerAttack3D.IsAttackNow)
        {
            _nowState = PlayerState.ATTACK;
        }
    }
    private void StateUpdateAction()
    {
        // 未解決 : IsActionNowの変更/更新
        if (_playerAction.IsActionNow)
        {
            _nowState = PlayerState.ACTION;
        }
    }
    private void StateUpdateDamage()
    {
        // 未解決 : IsDamageNowの変更/更新
        if (_damage3D.IsDamageNow)
        {
            _nowState = PlayerState.DAMAGE;
        }
    }
}