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
            Debug.Log("�f�B�����V������ύX���܂�");
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
        // ������DimensionManager��3D,2D��؂�ւ��閽�߂��L�q����B
        // DimensionManager.Instance.DimentionChange(); // 
    }

    /// <summary>
    /// �f�B�����V�����`�F���W���\�ɂ���
    /// �f�B�����V�����`�F���W�\�ȃG���A�ɐN����������
    /// ���s�����z��ō쐬�������\�b�h�B
    /// </summary>
    public void CanChangeDimension()
    {
        _isReadyDimensionChange = true;
    }
    /// <summary>
    /// �f�B�����V�����`�F���W��s�ɂ���
    /// �f�B�����V�����`�F���W�\�ȃG���A����ދ���������
    /// ���s�����z��ō쐬�������\�b�h�B
    /// </summary>
    public void CantChangeDimension()
    {
        _isReadyDimensionChange = false;
    }
}