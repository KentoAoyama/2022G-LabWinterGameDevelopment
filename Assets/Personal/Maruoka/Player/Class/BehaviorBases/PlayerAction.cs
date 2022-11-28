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
    /// �M�~�b�N�ғ��\�ɂ���B
    /// </summary>
    public void OnActionEnter(IGimmickEvent gimmick)
    {
        _gimmickHolder.Add(gimmick);
        _isReadyAction = true;
    }
    /// <summary>
    /// �M�~�b�N�ғ��s�ɂ���B
    /// </summary>
    public void OnActionExit(IGimmickEvent gimmick)
    {
        _gimmickHolder.Remove(gimmick);
        _isReadyAction = false;
    }
    public void Update()
    {
        // ���͂��������A�A�N�V�����\�����݃A�N�V�������Ŗ������
        // �M�~�b�N�A�N�V���������s����B
        if (IsRun())
        {
            StartAction();
        }
    }
    private bool IsRun()
    {
        bool result = false;

        result =
            Input_InputManager.Instance.       // ���͂�����
            GetInputDown(_actionButtonName) &&
            _isReadyAction &&                  // ���s�\�ȏ�Ԃł���
            (_stateController.CurrentState == PlayerState.IDLE ||       // ���s�\�ȃX�e�[�g�ł����true��Ԃ��B
            _stateController.CurrentState == PlayerState.MOVE);

        return result;
    }


    private void StartAction()
    {
        Debug.Log("�M�~�b�N�n��");
        // �M�~�b�N�Ɏ������ꂽ���\�b�h�����s��
        // �A�j���[�V�������Đ�����K�v������΃X�e�[�g��ύX����
        if (_gimmickHolder.Count != 0)
        {
            for (int i = 0; i < _gimmickHolder.Count; i++)
            {
                _gimmickHolder[i].GimmickEvent();
                if (_gimmickHolder[i].IsPlayAnimation)
                {
                    // �z�[���h���̃M�~�b�N���A�j���[�V�������Đ�����^�C�v�ł����
                    // �X�e�[�g���A�N�V�����ɕύX����B
                    _isActionNow = true;
                }
            }
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