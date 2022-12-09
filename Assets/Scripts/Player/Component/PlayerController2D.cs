using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : RetainedPlayerBehavior
{
    #region Inspector Variables
    [SerializeField]
    private PlayerMove2D _mover = default;
    [SerializeField]
    private PlayerAttack2D _attacker = default;
    [SerializeField]
    private PlayerDamage2D _damage = default;
    [SerializeField]
    private PlayerAction _actioner = default;
    [SerializeField]
    private PlayerStateController2D _stateController = default;
    [SerializeField]
    private PlayerDimensionChanger _dimensionChanger = default;
    [SerializeField]
    private PlayerAnimationController2D _animationController2D = default;

    [SerializeField]
    private Color _idleColor = Color.white;
    [SerializeField]
    private Color _moveColor = Color.white;
    [SerializeField]
    private Color _riseColor = Color.white;
    [SerializeField]
    private Color _fallColor = Color.white;
    [SerializeField]
    private Color _jumpColor = Color.white;
    [SerializeField]
    private Color _attackColor = Color.white;
    [SerializeField]
    private Color _actionColor = Color.white;
    [SerializeField]
    private Color _damageColor = Color.white;
    #endregion

    #region Unity Methods
    private void Start()
    {
        var rb2D = GetComponent<Rigidbody2D>();
        var groundChecker = GetComponent<GroundCheck>();
        _mover.Init(rb2D, groundChecker, _stateController);
        _attacker.Init(transform, _stateController);
        _damage.Init(rb2D, _stateController, _mover);
        _stateController.Init(rb2D, _mover, _attacker,
            _actioner, _damage, groundChecker);
        _actioner.Init(_stateController);
        _animationController2D.Init(transform.GetChild(0).GetComponent<Animator>(), _stateController);
        _dimensionChanger.Init(
            _stateController,
            FindObjectOfType<DimentionController>()
            .GetComponent<DimentionController>());

    }
    private void Update()
    {
        _stateController.Update();
        _attacker.Update();
        _actioner.Update();
        _dimensionChanger.Update();
        _damage.Update();
        _mover.Update();
        _animationController2D.Updata();
        //TestStateColorChange();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _dimensionChanger.ChangeableAreaTagName)
        {
            // �f�B�����V�����`�F���W�\�ɂ���B
            _dimensionChanger.CanChangeDimension();
        }
        if (collision.tag == _actioner.ActionableAreaTagName &&
            collision.TryGetComponent(out IGimmickEvent gimmick))
        {
            // �M�~�b�N�ғ��\�ɂ���
            _actioner.OnActionEnter(gimmick);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == _dimensionChanger.ChangeableAreaTagName)
        {
            // �f�B�����V�����`�F���W�s�ɂ���B
            _dimensionChanger.CantChangeDimension();
        }
        if (collision.tag == _actioner.ActionableAreaTagName &&
            collision.TryGetComponent(out IGimmickEvent gimmick))
        {
            // �M�~�b�N�ғ��s�ɂ���
            _actioner.OnActionExit(gimmick);
        }
    }
    private void OnDrawGizmosSelected()
    {
        OnDrawAttackArea();
    }
    #endregion

    #region Public Methods
    // �O������i�����W���[������j�Ă΂�邱�Ƃ�z�肵�č쐬���ꂽ�\�b�h�Q
    /// <summary>
    /// �_���[�W���� : <br/>
    /// �G����Ăяo����邱�Ƃ�z�肵�����\�b�h
    /// </summary>
    public void OnDamage(int value, Vector3 knockBackDir,
        float knockBackPower, int knockBackTime)
    {
        _damage.OnDamage(value, knockBackDir,
            knockBackPower, knockBackTime);
    }
    #endregion

    #region Animation Event
    // �A�j���[�V�����C�x���g�ŌĂяo�����Ƃ�z�肵�č쐬���ꂽ���\�b�h�Q
    /// <summary>
    /// �G���ɑ΂���h�U�������h
    /// </summary>
    public void AttackProcess()
    {
        _attacker.AttackProcess();
    }
    /// <summary>
    /// �U���̏I������ <br/>
    /// �U���A�j���[�V�����h�����h��
    /// �A�j���[�V�����C�x���g����Ăяo���B
    /// </summary>
    public void EndAttack()
    {
        _attacker.EndAttack();
    }
    /// <summary>
    /// �A�N�V�����̏I������ <br/>
    /// �A�N�V�����A�j���[�V�����h�����h��
    /// �A�j���[�V�����C�x���g����Ăяo���B
    /// </summary>
    public void EndAction()
    {
        _actioner.EndActionAnimation();
    }
    #endregion

    #region Debug
    private void OnDrawAttackArea()
    {
        if (_attacker.IsDrawGizmo)
        {
            Gizmos.color = _attacker.GizmoColor;
            var pos = _attacker.FirePosOffset;
            pos.x *= _stateController.FacingDirection == FacingDirection.RIGHT ? 1f : -1f;
            pos += transform.position;
            Gizmos.DrawCube(pos, _attacker.FireSize);
        }
    }
    #endregion

    #region Tests
    /// <summary>
    /// �_���[�W���󂯂鏈������肭���삵�Ă��邩
    /// �ǂ������m�F���邽�߂̃��\�b�h
    /// </summary>
    public void TestOnDamage()
    {
        _damage.OnDamage(0, Vector3.zero, 0f, 0);
    }
    /// <summary>
    /// �U����������肭���삵�Ă��邩�ǂ�����
    /// �m�F���邽�߂̃��\�b�h
    /// </summary>
    public void TestAttackProcess()
    {
        _attacker.AttackProcess();
    }
    /// <summary>
    /// �U���̏I������
    /// �i�{���͍U���A�j���[�V���������̃A�j���[�V�����C�x���g
    /// �@����Ăяo���B�j
    /// </summary>
    public void TestEndAttack()
    {
        _attacker.EndAttack();
    }
    public void TestEndAction()
    {
        _actioner.EndActionAnimation();
    }
    private void TestStateColorChange()
    {
        var _sprite = GetComponent<SpriteRenderer>();
        switch (_stateController.CurrentState)
        {
            case PlayerState.IDLE:
                _sprite.color = _idleColor;
                break;
            case PlayerState.MOVE:
                _sprite.color = _moveColor;
                break;
            case PlayerState.DAMAGE:
                _sprite.color = _damageColor;
                break;
            case PlayerState.ACTION:
                _sprite.color = _actionColor;
                break;
            case PlayerState.RISE:
                _sprite.color = _riseColor;
                break;
            case PlayerState.FALL:
                _sprite.color = _fallColor;
                break;
            case PlayerState.ATTACK:
                _sprite.color = _attackColor;
                break;
            case PlayerState.JUMP_2D:
                _sprite.color = _jumpColor;
                break;
        }
    }
    #endregion
}