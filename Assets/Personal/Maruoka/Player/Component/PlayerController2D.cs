using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    #region Inspector Variables
    [SerializeField]
    private PlayerDamage2D _damage = default;
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
        _mover.IsMove = !_damage.IsDamageNow;
        _mover.Update();
        _stateController.Update();
        _dimensionChanger.Update();
        _attacker.Update();
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
            // ギミック稼働可能にする
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
    // 外部から（他モジュールから）呼ばれることを想定して作成されたソッド群
    /// <summary>
    /// ダメージ処理 : <br/>
    /// 「敵から呼び出されるを想定したメソッド」
    /// </summary>
    public void OnDamage(int value, Vector3 knockBackDir,
        float knockBackPower, int knockBackTime)
    {
        _damage.OnDamage(value, knockBackDir,
            knockBackPower, knockBackTime);
    }
    /// <summary>
    /// アクション開始処理 : <br/>
    /// 「ギミックから呼び出されるを想定したメソッド」
    /// </summary>
    public void StartAction()
    {
        _actioner.StartAction();
    }
    #endregion

    #region Animation Event
    // アニメーションイベントで呼び出すことを想定して作成されたメソッド群
    /// <summary>
    /// 敵等に対する”攻撃処理”
    /// </summary>
    public void AttackProcess()
    {
        _attacker.AttackProcess();
    }
    /// <summary>
    /// 攻撃の終了処理 <br/>
    /// 攻撃アニメーション”末尾”の
    /// アニメーションイベントから呼び出す。
    /// </summary>
    public void EndAttack()
    {
        _attacker.EndAttack();
    }
    /// <summary>
    /// アクションの終了処理 <br/>
    /// アクションアニメーション”末尾”の
    /// アニメーションイベントから呼び出す。
    /// </summary>
    public void EndAction()
    {
        _actioner.EndAction();
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
    /// ダメージを受ける処理が上手く動作しているか
    /// どうかを確認するためのメソッド
    /// </summary>
    public void TestOnDamage()
    {
        _damage.OnDamage(0, Vector3.zero, 0f, 0);
    }
    /// <summary>
    /// 攻撃処理が上手く動作しているかどうかを
    /// 確認するためのメソッド
    /// </summary>
    public void TestAttackProcess()
    {
        _attacker.AttackProcess();
    }
    /// <summary>
    /// 攻撃の終了処理
    /// （本来は攻撃アニメーション末尾のアニメーションイベント
    /// 　から呼び出す。）
    /// </summary>
    public void TestEndAttack()
    {
        _attacker.EndAttack();
    }
    public void TestStartAction()
    {
        _actioner.StartAction();
    }
    public void TestEndAction()
    {
        _actioner.EndAction();
    }
    #endregion
}