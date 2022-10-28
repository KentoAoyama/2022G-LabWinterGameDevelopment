using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Mode _mode;

    PlayerMove _mover = default;
    PlayerAttack _attacker = default;
    PlayerAction _actioner = default;
    PlayerState _stater = default;

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
        _mover = new PlayerMove2D();
        _attacker = new PlayerAttack2D();
        _actioner = new PlayerAction2D();
        _stater = new PlayerStateController2D();
    }

    private void Initialize3DMode()
    {
        _mover = new PlayerMove3D();
    }
}

[System.Serializable]
public enum Mode
{
    Mode2D,
    Mode3D
}