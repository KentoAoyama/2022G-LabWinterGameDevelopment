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

    public void Update()
    {
        if (Input_InputManager.Instance.GetInputDown(_changeButton)
            && _isReadyDimensionChange)
        {
            Debug.Log("�f�B�����V������ύX���܂�");
            DimensionChange();
        }
    }
    private void DimensionChange()
    {
        // ������DimensionManager��3D,2D��؂�ւ��閽�߂��L�q����B
        // DimensionManager.Instance.DimentionChange(); // 
    }

    /// <summary>
    /// �f�B�����V�����`�F���W���\�ɂ���
    /// </summary>
    public void CanChangeDimension()
    {
        _isReadyDimensionChange = true;
    }
    /// <summary>
    /// �f�B�����V�����`�F���W��s�ɂ���
    /// </summary>
    public void CantChangeDimension()
    {
        _isReadyDimensionChange = false;
    }
}