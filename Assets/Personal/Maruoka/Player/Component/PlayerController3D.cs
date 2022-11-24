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
            // ディメンションチェンジ可能にする
            _dimensionChanger.CanChangeDimension();
        }
        if (other.tag == _actioner.ActionableAreaTagName &&
            other.TryGetComponent(out IGimmickEvent gimmick))
        {
            // ギミック稼働可能にする
            _actioner.OnActionEnter(gimmick);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == _dimensionChanger.ChangeableAreaTagName)
        {
            // ディメンションチェンジ不可にする
            _dimensionChanger.CantChangeDimension();
        }
        if (other.tag == _actioner.ActionableAreaTagName &&
            other.TryGetComponent(out IGimmickEvent gimmick))
        {
            // ギミック稼働不可にする
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
    /// ダメージ処理。
    /// 敵から呼び出される。
    /// </summary>
    public void OnDamage(int value, Vector3 knockBackDir,
        float knockBackPower, int knockBackTime)
    {
        _damage.OnDamage(value, knockBackDir,
            knockBackPower, knockBackTime);
    }
    #endregion

    #region Animation Event
    // アニメーションイベントから呼び出す想定で作成されたメソッド群

    /// <summary>
    /// 攻撃処理 <br/>
    /// 攻撃アニメーションから呼び出す。
    /// </summary>
    public void AttackProcess()
    {
        _attacker.AttackProcess();
    }
    /// <summary>
    /// 攻撃の終了処理 <br/>
    /// 攻撃アニメーション末尾の
    /// アニメーションイベントから呼び出す
    /// </summary>
    public void EndAttack()
    {
        _attacker.EndAttack();
    }
    /// <summary>
    /// ギミックアクションの終了処理 <br/>
    /// アクションアニメーション末尾の
    /// アニメーションイベントから呼び出す
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
    /// ダメージ処理が上手く動作するか
    /// どうかを確認するためのメソッド
    /// </summary>
    public void TestOnDamage()
    {
        _damage.OnDamage(0, Vector3.zero, 0, 0);
    }
    /// <summary>
    /// 攻撃処理が上手く動作するか
    /// どうかを確認するためのメソッド
    /// </summary>
    public void TestAttackProcess()
    {
        _attacker.AttackProcess();
    }
    /// <summary>
    /// 攻撃の終了処理が動作しているか
    /// どうか確認するためのメソッド
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