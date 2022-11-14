using System;
using UnityEngine;

[System.Serializable]
public class PlayerAction
{
    [SerializeField]
    protected bool _isReadyAction = false;
    [TagName, SerializeField]
    private string _actionableAreaTagName = default;

    private bool _isActionNow = false;

    public bool IsReadyAction => _isReadyAction;
    public string ActionableAreaTagName => _actionableAreaTagName;
    public bool IsActionNow => _isActionNow;

    /// <summary>
    /// ギミック稼働可能にする。
    /// </summary>
    public void OnActionEnter(IGimmickEvent gimmick)
    {
        _isReadyAction = true;
    }
    /// <summary>
    /// ギミック稼働不可にする。
    /// </summary>
    public void OnActionExit(IGimmickEvent gimmick) 
    {
        _isReadyAction = false;
    }
    public void StartAction()
    {
        _isActionNow = true;
    }
    public void EndAction()
    {
        _isActionNow = false;
    }
}