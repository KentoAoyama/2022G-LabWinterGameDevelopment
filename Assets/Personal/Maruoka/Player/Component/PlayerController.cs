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

    private PlayerMove _mover = default;
    private PlayerAttack _attacker = default;
    private PlayerAction _actioner = default;
    private PlayerStateController _stater = default;

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
        _attacker.OnFire();
        _stater.StateUpdate();
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
    #endregion

    private void Initialize2DMode()
    {
        _mover = new PlayerMove2D(
            GetComponent<Rigidbody2D>(), _moveSpeed, _jumpPower2D,
            _horizontalMoveButtonName, _jumpButtonName2D, GetComponent<GroundCheck>());
        _attacker = new PlayerAttack2D();
        _actioner = new PlayerAction2D();
        _stater = new PlayerStateController2D();
    }

    private void Initialize3DMode()
    {
        _mover = new PlayerMove3D(
            GetComponent<Rigidbody>(), _moveSpeed,
            _horizontalMoveButtonName);
        _attacker = new PlayerAttack3D();
        _actioner = new PlayerAction3D();
        _stater = new PlayerStateController3D();
        _railControler3D.Init(transform,_mover as PlayerMove3D);
    }
}

[System.Serializable]
public enum Mode
{
    Mode2D,
    Mode3D
}