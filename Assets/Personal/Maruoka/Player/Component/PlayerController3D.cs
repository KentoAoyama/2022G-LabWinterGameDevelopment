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

    [SerializeField]
    private Color _idleColor = Color.white;
    [SerializeField]
    private Color _moveColor = Color.white;
    [SerializeField]
    private Color _riseColor = Color.white;
    [SerializeField]
    private Color _fallColor = Color.white;
    [SerializeField]
    private Color _attackColor = Color.white;
    [SerializeField]
    private Color _actionColor = Color.white;
    [SerializeField]
    private Color _damageColor = Color.white;
    [SerializeField]
    private Color _stepColor = Color.white;
    #endregion

    #region Unity Methods
    private void Start()
    {
        var rb = GetComponent<Rigidbody>();
        _damage.Init(rb, _stateController);
        _attacker.Init(transform, _stateController);
        _mover.Init(rb, transform, _railControl, _stateController);
        _stateController.Init(rb, _mover, GetComponent<GroundCheck>(),
            _attacker, _actioner, _damage);
        _damage.Init(rb, _stateController);
        _actioner.Init(_stateController);
        // Test
        _renderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        _stateController.Update();
        _mover.Update();
        _dimensionChanger.Update();
        _attacker.Update();
        _actioner.Update();
        // Test
        TestStateColorChange();
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
    /// <summary>
    /// ステート遷移が問題ないか確認する為のメソッド
    /// </summary>
    private Renderer _renderer = null;
    private void TestStateColorChange()
    {
        switch (_stateController.CurrentState)
        {
            case PlayerState.IDLE:
                _renderer.material.color = _idleColor;
                break;
            case PlayerState.MOVE:
                _renderer.material.color = _moveColor;
                break;
            case PlayerState.DAMAGE:
                _renderer.material.color = _damageColor;
                break;
            case PlayerState.ACTION:
                _renderer.material.color = _actionColor;
                break;
            case PlayerState.RISE:
                _renderer.material.color = _riseColor;
                break;
            case PlayerState.FALL:
                _renderer.material.color = _fallColor;
                break;
            case PlayerState.ATTACK:
                _renderer.material.color = _attackColor;
                break;
            case PlayerState.STEP_3D:
                _renderer.material.color = _stepColor;
                break;
        }
    }
    #endregion
}