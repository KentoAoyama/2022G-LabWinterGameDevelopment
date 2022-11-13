using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    #region Inspector Variables
    [SerializeField]
    private Damage3D _damage = default;
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
        _mover.IsMove = !_damage.IsKnockBackNow;
        _mover.Update();
        _stateController.Update();
        _dimensionChanger.Update();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _dimensionChanger.ChangeableAreaTagName)
        {
            // ディメンションチェンジ可能にする
            _dimensionChanger.CanChangeDimension();
        }
        if (other.tag == _actioner.ActionableAreaTagName &&
            other.TryGetComponent(out IGimmickEvent gimmick))
        {
            _actioner.OnActionEnter(gimmick);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == _dimensionChanger.ChangeableAreaTagName)
        {
            //ディメンションチェンジ不可にする
            _dimensionChanger.CantChangeDimension();
        }
        if (other.tag == _actioner.ActionableAreaTagName &&
            other.TryGetComponent(out IGimmickEvent gimmick))
        {
            _actioner.OnActionExit(gimmick);
        }
    }
    private void OnDrawGizmosSelected()
    {
        OnDrawAttackArea();
    }
    #endregion

    #region Public Methods
    public void TestOnDamage()
    {
        _damage.OnDamage(0, Vector3.zero, 0, 0);
    }
    #endregion

    #region Animation Event
    public void OnFire()
    {
        _attacker.Fire();
    }
    #endregion

    #region Private Methods
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
}