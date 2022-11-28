using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAction
{
    [InputName, SerializeField]
    private string _actionButtonName = default;
    [SerializeField]
    private bool _isReadyAction = false;
    [SerializeField]
    private bool _isActionNow = false;
    [TagName, SerializeField]
    private string _actionableAreaTagName = default;


    private List<IGimmickEvent> _gimmickHolder = new();

    public bool IsReadyAction => _isReadyAction;
    public string ActionableAreaTagName => _actionableAreaTagName;
    public bool IsActionNow { get => _isActionNow; set => _isActionNow = value; }
    private PlayerStateController _stateController;

    public void Init(PlayerStateController stateController)
    {
        _stateController = stateController;
    }
    /// <summary>
    /// ギミック稼働可能にする。
    /// </summary>
    public void OnActionEnter(IGimmickEvent gimmick)
    {
        _gimmickHolder.Add(gimmick);
        _isReadyAction = true;
    }
    /// <summary>
    /// ギミック稼働不可にする。
    /// </summary>
    public void OnActionExit(IGimmickEvent gimmick)
    {
        _gimmickHolder.Remove(gimmick);
        _isReadyAction = false;
    }
    public void Update()
    {
        // 入力が発生し、アクション可能かつ現在アクション中で無ければ
        // ギミックアクションを実行する。
        if (IsRun())
        {
            StartAction();
        }
    }
    private bool IsRun()
    {
        bool result = false;

        result =
            Input_InputManager.Instance.       // 入力があり
            GetInputDown(_actionButtonName) &&
            _isReadyAction &&                  // 実行可能な状態であり
            (_stateController.CurrentState == PlayerState.IDLE ||       // 実行可能なステートであればtrueを返す。
            _stateController.CurrentState == PlayerState.MOVE);

        return result;
    }


    private void StartAction()
    {
        Debug.Log("ギミック始動");
        // ギミックに実装されたメソッドを実行し
        // アニメーションを再生する必要があればステートを変更する
        if (_gimmickHolder.Count != 0)
        {
            for (int i = 0; i < _gimmickHolder.Count; i++)
            {
                _gimmickHolder[i].GimmickEvent();
                if (_gimmickHolder[i].IsPlayAnimation)
                {
                    // ホールド中のギミックがアニメーションを再生するタイプであれば
                    // ステートをアクションに変更する。
                    _isActionNow = true;
                }
            }
        }
        else
        {
            Debug.LogWarning("開始すべきギミックがホールドされていません");
        }
    }
    public void EndActionAnimation()
    {
        _isActionNow = false;
    }
}