using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    #region Inspector Variables
    [SerializeField]
    private Damage2D _damage = default;
    [SerializeField]
    private PlayerAction2D _actioner = default;
    [SerializeField]
    private PlayerAttack2D _attacker = default;
    [SerializeField]
    private PlayerMove2D _mover = default;
    [SerializeField]
    private PlayerStateController2D _stateController = default;
    #endregion

    #region Unity Methods
    private void Start()
    {
        var rb2D = GetComponent<Rigidbody2D>();
        _damage.Init(rb2D);
        _attacker.Init(transform, _stateController);
        Debug.Log(GetComponent<GroundCheck>());
        _mover.Init(rb2D, GetComponent<GroundCheck>());
        _stateController.Init(rb2D);

    }
    private void Update()
    {
        _mover.Update();
        _stateController.Update();
    }
    private void OnDrawGizmosSelected()
    {
        OnDrawAttackArea();
    }
    #endregion

    #region Public Methods
    public void OnDamage()
    {
        //_damage.OnDamage();
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