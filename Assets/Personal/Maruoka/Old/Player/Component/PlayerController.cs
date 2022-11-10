using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Mode _mode;

    [InputName, SerializeField]
    private string _dimensionChangeKey = "";

    [Header("�ړ��֘A")]
    [Tooltip("�ړ����x"), SerializeField]
    private float _moveSpeed = 1f;
    [Tooltip("�W�����v�� : 2D�̂�"), SerializeField]
    private float _jumpPower2D = 1f;
    [Tooltip("�ړ��{�^���̖��O"), InputName, SerializeField]
    private string _horizontalMoveButtonName = "";
    [Tooltip("�W�����v�{�^���̖��O : 2D�̂�"), InputName, SerializeField]
    private string _jumpButtonName2D = "";

    [Header("���[���R���g���[���[�i3D�̋����j")]
    [SerializeField]
    private RailControl3D _railControler3D = default;

    [Header("�U���֘A")]
    [InputName, SerializeField]
    private string _fireButtonName = default;
    [SerializeField]
    private Vector3 _attackPosOffset = default;
    [SerializeField]
    private Vector3 _attackAreaSize = default;
    [SerializeField]
    private LayerMask _attackTargetLayer = default;
    [SerializeField]
    private Color _attackAreaGizmoColor = Color.red;

    private PlayerMove _mover = default;
    private PlayerAttack _attacker = default;
    private PlayerAction _actioner = default;
    private PlayerStateController _stater = default;
    private PlayerDamage _damage = default;

    private PlayerDimensionChanger _dimensionChanger = new PlayerDimensionChanger();

    #region Unity Methods
    private void Start()
    {
        if (_mode == Mode.Mode2D)
        {
            Initialize2DMode();
        }
        else if (_mode == Mode.Mode3D)
        {
            Initialize3DMode();
        }
#if UNITY_EDITOR
        else
        {
            Debug.LogError("�s���Ȓl�ł��I�C�����Ă��������I");
            UnityEditor.EditorApplication.isPlaying = false;
        }
#endif
    }
    private void Update()
    {
        _mover.Move();
        _stater.Update();
        _dimensionChanger.Detection(_dimensionChangeKey);

        if (_mode == Mode.Mode3D)
        {
            _railControler3D.Process();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_actioner is PlayerAction3D && other.TryGetComponent(out IGimmickEvent gimmick))
        {
            _actioner.OnActionEnter(gimmick);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_actioner is PlayerAction3D && other.TryGetComponent(out IGimmickEvent gimmick))
        {
            _actioner.OnActionExit(gimmick);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_actioner is PlayerAction2D && collision.TryGetComponent(out IGimmickEvent gimmick))
        {
            _actioner.OnActionEnter(gimmick);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_actioner is PlayerAction3D && collision.TryGetComponent(out IGimmickEvent gimmick))
        {
            _actioner.OnActionExit(gimmick);
        }
    }

    private void OnDrawGizmosSelected()
    {
        OnDrawGizmos_AttackArea();
    }
    #endregion

    private void Initialize2DMode()
    {
        var rb2D = GetComponent<Rigidbody2D>();
        _mover = new PlayerMove2D(
            rb2D, _moveSpeed, _jumpPower2D,
            _horizontalMoveButtonName, _jumpButtonName2D,
            GetComponent<GroundCheck>());
        _actioner = new PlayerAction2D();
        _stater = new PlayerStateController2D(rb2D);
        _attacker = new PlayerAttack2D(
            _stater, _fireButtonName, transform,
            _attackPosOffset, _attackAreaSize, _attackTargetLayer);
        _damage = new Damage2D();
    }

    private void Initialize3DMode()
    {
        var rb = GetComponent<Rigidbody>();
        _mover = new PlayerMove3D(
            rb, _moveSpeed,
            _horizontalMoveButtonName);
        _actioner = new PlayerAction3D();
        _stater = new PlayerStateController3D(rb);
        _attacker = new PlayerAttack3D(_stater, _fireButtonName, transform,
            _attackPosOffset, _attackAreaSize, _attackTargetLayer);
        _railControler3D.Init(transform, _mover as PlayerMove3D);
        _damage = new Damage3D(rb);
    }

    #region Animation Event
    // �A�j���[�V�����C�x���g����Ăяo�����Ƃ�z�肵�č쐬�������\�b�h�Q
    public void OnFire()
    {
        _attacker.OnFire();
    }
    #endregion

    #region Test
    // �e�X�g�R�[�h�Q
    private void OnDrawGizmos_AttackArea()
    {
        Gizmos.color = _attackAreaGizmoColor;
        // �ʒu��ݒ肷��B
        var pos = _attackPosOffset;
        // �����ɉ����Ĉʒu�𒲐�����
        // pos.x *= _stater.FacingDirection == FacingDirection.RIGHT ? 1f : -1f;
        if (_stater?.FacingDirection == FacingDirection.LEFT)
        {
            pos.x *= -1f;
        }
        pos += transform.position;
        // �`�悷��
        Gizmos.DrawCube(
            pos,
            _attackAreaSize);
    }
    public void OnDamage(int value)
    {
        _damage.OnDamage(value);
    }
    #endregion
}

[System.Serializable]
public enum Mode
{
    Mode2D,
    Mode3D
}