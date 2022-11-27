using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerAttack
{
    protected PlayerStateController _stateController = default;
    protected Transform _transform = default;
    private bool _isAttackNow = false;

    [SerializeField]
    private bool _isReadyAttack = false;
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
    public bool IsAttackNow => _isAttackNow;


    public void Init(Transform transform,
        PlayerStateController stateController)
    {
        _transform = transform;
        _stateController = stateController;
    }
    public void Update(PlayerState state)
    {
        // 攻撃可能状態かつ、攻撃入力が発生した時攻撃を開始する。
        if (IsRun(state))
        {
            StartAttack();
        }
    }
    private bool IsRun(PlayerState state)
    {
        bool result = false;

        result =
            Input_InputManager.Instance.
            GetInputDown(_fireButtonName) &&
            state == PlayerState.IDLE ||
            state == PlayerState.MOVE;

        return result;
    }
    public abstract void AttackProcess();

    public void StartAttack()
    {
        _isAttackNow = true;
    }
    public void EndAttack()
    {
        _isAttackNow = false;
    }

    public Vector3 GetFirePos()
    {
        var pos = _firePosOffset;

        pos.x *= _stateController.FacingDirection == FacingDirection.RIGHT ? 1f : -1f;

        pos += _transform.position;

        return pos;
    }
}