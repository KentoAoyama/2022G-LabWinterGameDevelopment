using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    #region Inspector Variables
    [SerializeField]
    private PlayerDamage2D _damage = default;
    [SerializeField]
    private PlayerAction _actioner = default;
    [SerializeField]
    private PlayerAttack2D _attacker = default;
    [SerializeField]
    private PlayerMove2D _mover = default;
    [SerializeField]
    private PlayerStateController2D _stateController = default;
    [SerializeField]
    private PlayerDimensionChanger _dimensionChanger = default;
    #endregion

    #region Unity Methods
    private void Start()
    {
        var rb2D = GetComponent<Rigidbody2D>();
        var groundChecker = GetComponent<GroundCheck>();
        _damage.Init(rb2D);
        _attacker.Init(transform, _stateController);
        _mover.Init(rb2D, groundChecker);
        _stateController.Init(rb2D, _mover, _attacker,
            _actioner, _damage, groundChecker);

    }
    private void Update()
    {
        _mover.IsMove = !_damage.IsDamageNow;
        _mover.Update();
        _stateController.Update();
        _dimensionChanger.Update();
        _attacker.Update();
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
    /// �u�G����Ăяo������z�肵�����\�b�h�v
    /// </summary>
    public void OnDamage(int value, Vector3 knockBackDir,
        float knockBackPower, int knockBackTime)
    {
        _damage.OnDamage(value, knockBackDir,
            knockBackPower, knockBackTime);
    }
    /// <summary>
    /// �A�N�V�����J�n���� : <br/>
    /// �u�M�~�b�N����Ăяo������z�肵�����\�b�h�v
    /// </summary>
    public void StartAction()
    {
        _actioner.StartAction();
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
        _actioner.EndAction();
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
    public void TestStartAction()
    {
        _actioner.StartAction();
    }
    public void TestEndAction()
    {
        _actioner.EndAction();
    }
    #endregion
}