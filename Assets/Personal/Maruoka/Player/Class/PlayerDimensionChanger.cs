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

    private PlayerStateController _stateController = null;

    private void Init(PlayerStateController stateController)
    {
        _stateController = stateController;
    }

    public void Update()
    {
        if (IsRun())
        {
            Debug.Log("ディメンションを変更します");
            DimensionChange();
        }
    }
    private bool IsRun()
    {
        bool result = false;

        result =
            _isReadyDimensionChange &&
            Input_InputManager.Instance.
            GetInputDown(_changeButton) &&
            (_stateController.CurrentState == PlayerState.IDLE ||
            _stateController.CurrentState == PlayerState.MOVE);

        return result;
    }
    private void DimensionChange()
    {
        // ここにDimensionManagerに3D,2Dを切り替える命令を記述する。
        // DimensionManager.Instance.DimentionChange(); // 
    }

    /// <summary>
    /// ディメンションチェンジを可能にする
    /// ディメンションチェンジ可能なエリアに侵入した時に
    /// 実行される想定で作成したメソッド。
    /// </summary>
    public void CanChangeDimension()
    {
        _isReadyDimensionChange = true;
    }
    /// <summary>
    /// ディメンションチェンジを不可にする
    /// ディメンションチェンジ可能なエリアから退去した時に
    /// 実行される想定で作成したメソッド。
    /// </summary>
    public void CantChangeDimension()
    {
        _isReadyDimensionChange = false;
    }
}