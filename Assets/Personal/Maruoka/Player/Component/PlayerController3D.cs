using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    #region Inspector Variables
    [SerializeField]
    private PlayerDamage3D _damage = default;
    [SerializeField]
    private PlayerAction _actioner = default;
    [SerializeField]
    private PlayerAttack3D _attacker = default;
    [SerializeField]
    private PlayerMove3D _mover = default;
    [SerializeField]
    private PlayerStateController3D _stateController = default;
    [SerializeField]
    private RailControl3D _railControl = default;
    [SerializeField]
    private PlayerDimensionChanger _dimensionChanger = default;
    #endregion

    #region Unity Methods
    private void Start()
    {
        var rb = GetComponent<Rigidbody>();
        _damage.Init(rb);
        _attacker.Init(transform, _stateController);
        _mover.Init(rb, transform, _railControl);
        _stateController.Init(rb, _mover, GetComponent<GroundCheck>(),
            _attacker, _actioner, _damage);
    }
    private void Update()
    {
        _stateController.Update();
        _mover.Update(_stateController.NowState);
        _dimensionChanger.Update(_stateController.NowState);
        _attacker.Update(_stateController.NowState);
        _actioner.Update(_stateController.NowState);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _dimensionChanger.ChangeableAreaTagName)
        {
            // �f�B�����V�����`�F���W�\�ɂ���
            _dimensionChanger.CanChangeDimension();
        }
        if (other.tag == _actioner.ActionableAreaTagName &&
            other.TryGetComponent(out IGimmickEvent gimmick))
        {
            // �M�~�b�N�ғ��\�ɂ���
            _actioner.OnActionEnter(gimmick);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == _dimensionChanger.ChangeableAreaTagName)
        {
            // �f�B�����V�����`�F���W�s�ɂ���
            _dimensionChanger.CantChangeDimension();
        }
        if (other.tag == _actioner.ActionableAreaTagName &&
            other.TryGetComponent(out IGimmickEvent gimmick))
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
    /// <summary>
    /// �_���[�W�����B
    /// �G����Ăяo�����B
    /// </summary>
    public void OnDamage(int value, Vector3 knockBackDir,
        float knockBackPower, int knockBackTime)
    {
        _damage.OnDamage(value, knockBackDir,
            knockBackPower, knockBackTime);
    }
    #endregion

    #region Animation Event
    // �A�j���[�V�����C�x���g����Ăяo���z��ō쐬���ꂽ���\�b�h�Q

    /// <summary>
    /// �U������ <br/>
    /// �U���A�j���[�V��������Ăяo���B
    /// </summary>
    public void AttackProcess()
    {
        _attacker.AttackProcess();
    }
    /// <summary>
    /// �U���̏I������ <br/>
    /// �U���A�j���[�V����������
    /// �A�j���[�V�����C�x���g����Ăяo��
    /// </summary>
    public void EndAttack()
    {
        _attacker.EndAttack();
    }
    /// <summary>
    /// �M�~�b�N�A�N�V�����̏I������ <br/>
    /// �A�N�V�����A�j���[�V����������
    /// �A�j���[�V�����C�x���g����Ăяo��
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
    /// �_���[�W��������肭���삷�邩
    /// �ǂ������m�F���邽�߂̃��\�b�h
    /// </summary>
    public void TestOnDamage()
    {
        _damage.OnDamage(0, Vector3.zero, 0, 0);
    }
    /// <summary>
    /// �U����������肭���삷�邩
    /// �ǂ������m�F���邽�߂̃��\�b�h
    /// </summary>
    public void TestAttackProcess()
    {
        _attacker.AttackProcess();
    }
    /// <summary>
    /// �U���̏I�����������삵�Ă��邩
    /// �ǂ����m�F���邽�߂̃��\�b�h
    /// </summary>
    public void TestAttackEnd()
    {
        _attacker.EndAttack();
    }
    public void TestEndGimmick()
    {
        _actioner.EndActionAnimation();
    }
    #endregion
}