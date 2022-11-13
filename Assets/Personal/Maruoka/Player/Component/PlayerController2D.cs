using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    #region Inspector Variables
    [SerializeField]
    private Damage2D _damage = default;
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
        _mover.IsMove = !_damage.IsKnockBackNow;
        _mover.Update();
        _stateController.Update();
        _dimensionChanger.Update();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _dimensionChanger.ChangeableAreaTagName)
        {
            // ディメンションチェンジ可能にする。
            _dimensionChanger.CanChangeDimension();
        }
        if (collision.tag == _actioner.ActionableAreaTagName &&
            collision.TryGetComponent(out IGimmickEvent gimmick))
        {
            _actioner.OnActionEnter(gimmick);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == _dimensionChanger.ChangeableAreaTagName)
        {
            // ディメンションチェンジ不可にする。
            _dimensionChanger.CantChangeDimension();
        }
        if (collision.tag == _actioner.ActionableAreaTagName &&
            collision.TryGetComponent(out IGimmickEvent gimmick))
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
        _damage.OnDamage(0, Vector3.zero, 0f, 0);
    }
    #endregion

    #region Private Methods
    #endregion

    #region Animation Event
    public void OnFire()
    {
        _attacker.Fire();
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

}