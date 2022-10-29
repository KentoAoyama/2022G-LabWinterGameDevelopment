using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Mode _mode;

    [InputName, SerializeField]
    private string _dimensionChangeKey = "";

    [Header("2D移動関連")]
    [Tooltip("移動速度"), SerializeField]
    private float _moveSpeed = 1f;
    [Tooltip("ジャンプ力"), SerializeField]
    private float _jumpPower = 1f;
    [Tooltip("移動ボタンの名前"), InputName, SerializeField]
    private string _horizontalMoveButtonName = "";
    [Tooltip("移動ボタンの名前"), InputName, SerializeField]
    private string _jumpButtonName = "";



    private PlayerMove _mover = default;
    private PlayerAttack _attacker = default;
    private PlayerAction _actioner = default;
    private PlayerState _stater = default;

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
            Debug.LogError("不正な値です！修正してください！");
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
            GetComponent<Rigidbody2D>(), _moveSpeed, _jumpPower,
            _horizontalMoveButtonName, _jumpButtonName, GetComponent<GroundCheck>());
        _attacker = new PlayerAttack2D();
        _actioner = new PlayerAction2D();
        _stater = new PlayerStateController2D();
    }

    private void Initialize3DMode()
    {
        _mover = new PlayerMove3D(GetComponent<Rigidbody>(), _moveSpeed, _horizontalMoveButtonName);
        _attacker = new PlayerAttack3D();
        _actioner = new PlayerAction3D();
        _stater = new PlayerStateController3D();
    }
}

[System.Serializable]
public enum Mode
{
    Mode2D,
    Mode3D
}