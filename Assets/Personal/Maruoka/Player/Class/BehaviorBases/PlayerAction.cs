using System;
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


    private IGimmickEvent _gimmickHolder = null;

    public bool IsReadyAction => _isReadyAction;
    public string ActionableAreaTagName => _actionableAreaTagName;
    public bool IsActionNow => _isActionNow;

    /// <summary>
    /// ギミック稼働可能にする。
    /// </summary>
    public void OnActionEnter(IGimmickEvent gimmick)
    {
        _gimmickHolder = gimmick;
        _isReadyAction = true;
    }
    /// <summary>
    /// ギミック稼働不可にする。
    /// </summary>
    public void OnActionExit(IGimmickEvent gimmick)
    {
        _gimmickHolder = null;
        _isReadyAction = false;
    }
    public void Update()
    {
        // 入力が発生し、アクション可能かつ現在アクション中で無ければ
        // ギミックアクションを実行する。
        if (Input_InputManager.Instance.GetInputDown(_actionButtonName) &&
            _isReadyAction && !_isActionNow)
        {
            StartAction(_gimmickHolder);
        }
    }
    private void StartAction(IGimmickEvent gimmick)
    {
        Debug.Log("ギミック始動");
        // ギミックに実装されたメソッドを実行し
        // アニメーションを再生する必要があればステートを変更する
        if (_gimmickHolder != null)
        {
            gimmick.GimmickEvent();
            _isActionNow = gimmick.IsPlayAnimation;
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