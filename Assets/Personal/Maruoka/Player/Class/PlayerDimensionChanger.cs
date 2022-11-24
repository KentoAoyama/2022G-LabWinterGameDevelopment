using System;
using UnityEngine;

[System.Serializable]
public class PlayerDimensionChanger
{
    public bool IsReadyDimensionChange => _isReadyDimensionChange;

    [InputName, SerializeField]
    private string _changeButton = default;
    [TagName, SerializeField]
    private string _changeableAreaTagName = default;
    [SerializeField]
    protected bool _isReadyDimensionChange = false;
    public string ChangeableAreaTagName => _changeableAreaTagName;

    public void Update(PlayerState state)
    {
        if (IsRun(state))
        {
            Debug.Log("ディメンションを変更します");
            DimensionChange();
        }
    }
    private bool IsRun(PlayerState state)
    {
        bool result = false;

        result =
            Input_InputManager.Instance.
            GetInputDown(_changeButton) &&
            state == PlayerState.IDLE ||
            state == PlayerState.MOVE;

        return result;
    }
    private void DimensionChange()
    {
        // ここにDimensionManagerに3D,2Dを切り替える命令を記述する。
        // DimensionManager.Instance.DimentionChange(); // 
    }

    /// <summary>
    /// ディメンションチェンジを可能にする
    /// </summary>
    public void CanChangeDimension()
    {
        _isReadyDimensionChange = true;
    }
    /// <summary>
    /// ディメンションチェンジを不可にする
    /// </summary>
    public void CantChangeDimension()
    {
        _isReadyDimensionChange = false;
    }
}