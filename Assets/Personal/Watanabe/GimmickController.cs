using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gimmick(�C�x���g)�̓��e���L�q(�����A���΁A���o�[�A�G���x�[�^�[�A�����J���ATimeLine���s��)
/// �ʒm����������Gimmick�������Ă���C�x���g�����s����
/// �C�x���g���������s���ꂽ���Z�[�u�����s����(DataSave.cs�Ŏ��s)?
/// </summary>
public class GimmickController : MonoBehaviour
{
    [Tooltip("�ō��̉�")]
    [SerializeField] private float _maxTemp = 37.0f;
    [Tooltip("�e�X�g�p�̑̉�")]
    [SerializeField, Range(10.0f, 40.0f)] private float _testTemp = 10.0f;
    [Tooltip("����(���΂ɐG���Ƒ̉��㏸)")]
    [SerializeField] private bool _isTorch = false;
    /// <summary> Player�����o�[�ɐڐG�����ۂ̃t���O </summary>
    public bool IsTouchLever { get; set; }
    /// <summary> ����(���΂ɐG���Ƒ̉��㏸) </summary>
    public bool IsTorch { get => _isTorch; set => _isTorch = value; }

    private void Update()
    {
        if (IsTorch == true)
        {
            //�����ŁA�̉����㏸��������̂��Ăяo��(�ȉ��̊֐��̓e�X�g�p)
            Torch();
        }
    }

    public void Clear()
    {
        //EventManager�ɃN���A���ꂽ���Ƃ�ʒm���AGimmick�������Ă���C�x���g�����s
        //ex. �G���x�[�^�[�������ATimeLine��
        if (IsTouchLever == true)
        {
            //�����J���A�G���x�[�^�[�㏸�̏���(Animation��)
        }
    }

    /// <summary>
    /// Torch...���������΂ɐG��Ă���ԑ̉����������㏸����
    /// </summary>
    public void Torch()
    {
        //���Ԍo�߂ɍ��킹�đ̉����㏸����(���ۂɑ̉����㏸�����鏈���́APlayer�̕��ŋL�q)
        _testTemp += Time.deltaTime;
        //���̑̉��܂ŏオ�����炻���Ŏ~�߂�
        if (_testTemp > _maxTemp)
        {
            _testTemp = _maxTemp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //���o�[�ɐG�ꂽ�ꍇ��
        if (other.gameObject.CompareTag("Lever"))
        {
            IsTouchLever = true;
        }
        //����(Bonfire)�ƐڐG�����ꍇ��
        else if (other.gameObject.CompareTag("Bonfire"))
        {
            IsTorch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Player�����o�[���痣�ꂽ����Gimmick���I������
        IsTouchLever = false;
        //Player�����΂��痣�ꂽ����Gimmick���I������
        IsTorch = false;
    }
}
