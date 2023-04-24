using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerAttack
{
    protected PlayerStateController _stateController = default;
    protected Transform _transform = default;
    [SerializeField]
    private bool _isAttackNow = false;

    [InputName, SerializeField]
    protected string _fireButtonName = default;
    [SerializeField]
    protected Vector3 _firePosOffset = default;
    [SerializeField]
    protected Vector3 _fireSize = default;
    [SerializeField]
    protected LayerMask _targetLayer = default;
    [SerializeField]
    protected bool _isDrawGizmo = false;
    [SerializeField]
    protected Color _gizmoColor = Color.red;

    public Vector3 FirePosOffset => _firePosOffset;
    public Vector3 FireSize => _fireSize;
    public Color GizmoColor => _gizmoColor;
    public bool IsDrawGizmo => _isDrawGizmo;
    public bool IsAttackNow { get => _isAttackNow; set => _isAttackNow = value; }


    public void Init(Transform transform,
        PlayerStateController stateController)
    {
        _transform = transform;
        _stateController = stateController;
    }
    public void Update()
    {
        // �U���\��Ԃ��A�U�����͂������������U�����J�n����B
        if (IsRun())
        {
            StartAttack();
        }
        StateUpdate();
    }
    private bool IsRun()
    {
        bool result = false;

        result =
            !_isAttackNow &&
            Input_InputManager.Instance.GetInputDown(_fireButtonName) &&
            (_stateController.CurrentState == PlayerState.IDLE ||
            _stateController.CurrentState == PlayerState.MOVE);

        return result;
    }
    protected void StateUpdate()
    {
        if (_isAttackNow)
        {
            _stateController.CurrentState = PlayerState.ATTACK;
        }
    }
    public abstract void AttackProcess();

    public void StartAttack()
    {
        // �A�^�b�N�A�j���[�V�����Đ��J�n
        _isAttackNow = true;
    }
    private float _fireInterval = 1f;
    public async void EndAttack()
    {
        // �U���A�j���[�V�����Đ��I��
        _isAttackNow = false;
        await System.Threading.Tasks.Task.Delay((int)(_fireInterval * 1000f));
    }

    public Vector3 GetFirePos()
    {
        var pos = _firePosOffset;

        pos.x *= _stateController.FacingDirection == FacingDirection.RIGHT ? 1f : -1f;

        pos += _transform.position;

        return pos;
    }
}