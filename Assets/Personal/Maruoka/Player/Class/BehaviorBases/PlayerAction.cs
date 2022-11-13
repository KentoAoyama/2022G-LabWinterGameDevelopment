using System;
using UnityEngine;

[System.Serializable]
public abstract class PlayerAction
{
    [SerializeField]
    protected bool _isReadyAction = false;
    [TagName, SerializeField]
    private string _actionableAreaTagName = default;

    private bool _isActionNow = false;

    public bool IsReadyAction => _isReadyAction;
    public string ActionableAreaTagName => _actionableAreaTagName;
    public bool IsActionNow => _isActionNow;

    public void OnActionEnter(IGimmickEvent gimmick)
    {
        _isReadyAction = true;
    }
    public void OnActionExit(IGimmickEvent gimmick) 
    {
        _isReadyAction = false;
    }
}