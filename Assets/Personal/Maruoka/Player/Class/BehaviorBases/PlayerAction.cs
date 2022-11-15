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
    /// �M�~�b�N�ғ��\�ɂ���B
    /// </summary>
    public void OnActionEnter(IGimmickEvent gimmick)
    {
        _gimmickHolder = gimmick;
        _isReadyAction = true;
    }
    /// <summary>
    /// �M�~�b�N�ғ��s�ɂ���B
    /// </summary>
    public void OnActionExit(IGimmickEvent gimmick)
    {
        _gimmickHolder = null;
        _isReadyAction = false;
    }
    public void Update()
    {
        // ���͂��������A�A�N�V�����\�����݃A�N�V�������Ŗ������
        // �M�~�b�N�A�N�V���������s����B
        if (Input_InputManager.Instance.GetInputDown(_actionButtonName) &&
            _isReadyAction && !_isActionNow)
        {
            StartAction(_gimmickHolder);
        }
    }
    private void StartAction(IGimmickEvent gimmick)
    {
        Debug.Log("�M�~�b�N�n��");
        // �M�~�b�N�Ɏ������ꂽ���\�b�h�����s��
        // �A�j���[�V�������Đ�����K�v������΃X�e�[�g��ύX����
        if (_gimmickHolder != null)
        {
            gimmick.GimmickEvent();
            _isActionNow = gimmick.IsPlayAnimation;
        }
        else
        {
            Debug.LogWarning("�J�n���ׂ��M�~�b�N���z�[���h����Ă��܂���");
        }
    }
    public void EndActionAnimation()
    {
        _isActionNow = false;
    }
}