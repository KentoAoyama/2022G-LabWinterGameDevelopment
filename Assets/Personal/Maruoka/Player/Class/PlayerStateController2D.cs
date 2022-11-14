using System;
using UnityEngine;

[System.Serializable]
public class PlayerStateController2D : PlayerStateController
{
    private Rigidbody2D _rb2D = default;
    private PlayerMove2D _playerMove2D = default;
    private GroundCheck _groundCheck = default;
    private PlayerAttack2D _playerAttack2D = default;
    private PlayerAction _playerAction = default;
    private PlayerDamage2D _damage2D = default;

    public void Init(Rigidbody2D rb2D, PlayerMove2D playerMove2D,
        PlayerAttack2D playerAttack2D, PlayerAction playerAction,
        PlayerDamage2D damage2D, GroundCheck groundCheck)
    {
        _rb2D = rb2D;
        _playerMove2D = playerMove2D;
        _playerAttack2D = playerAttack2D;
        _playerAction = playerAction;
        _damage2D = damage2D;
        _groundCheck = groundCheck;
    }
    public override void Update()
    {
        StateUpdate();
        FacingDirectionUpdate();
    }

    private void StateUpdate()
    {
        _nowState = PlayerState.IDLE;

        StateUpdateMove();
        StateUpdateJump();
        StateUpdateRise();
        StateUpdateFall();
        StateUpdateAttack();
        StateUpdateAction();
        StateUpdateDamage();
    }

    private void FacingDirectionUpdate()
    {
        // �����Ă���������X�V����
        if (!Mathf.Approximately(_rb2D.velocity.x, 0f))
        {
            if (_rb2D.velocity.x > 0f)
            {
                FacingDirection = FacingDirection.RIGHT;
            }
            else if (_rb2D.velocity.x < 0f)
            {
                FacingDirection = FacingDirection.LEFT;
            }
        }
    }


    private void StateUpdateMove()
    {
        if (!Mathf.Approximately(_rb2D.velocity.x, 0f))
        {
            _nowState = PlayerState.MOVE;
        }
    }
    private void StateUpdateJump()
    {
        if (_playerMove2D.IsJump)
        {
            _nowState = PlayerState.JUMP_2D;
        }
    }
    private void StateUpdateRise()
    {
        // �ڒn���Ă��炸�A�W�����v���łȂ��A�㏸���ł���΁A
        // �㏸�X�e�[�g�ɕύX����B
        if (!_groundCheck.IsGround2D() &&
            !_playerMove2D.IsJump &&
             _rb2D.velocity.y > 0.01f)
        {
            _nowState = PlayerState.RISE;
        }
    }
    private void StateUpdateFall()
    {
        // �ڒn���Ă��炸�A�W�����v���łȂ��A�������ł���΁A
        // �����X�e�[�g�ɕύX����B
        if (!_groundCheck.IsGround2D() &&
            !_playerMove2D.IsJump &&
             _rb2D.velocity.y < 0.01f)
        {
            _nowState = PlayerState.FALL;
        }
    }
    private void StateUpdateAttack()
    {
        if (_playerAttack2D.IsAttackNow)
        {
            _nowState = PlayerState.ATTACK;
        }
    }
    private void StateUpdateAction()
    {
        // ������ : IsActionNow�̕ύX/�X�V
        if (_playerAction.IsActionNow)
        {
            _nowState = PlayerState.ACTION;
        }
    }
    private void StateUpdateDamage()
    {
        if (_damage2D.IsDamageNow)
        {
            _nowState = PlayerState.DAMAGE;
        }
    }
}