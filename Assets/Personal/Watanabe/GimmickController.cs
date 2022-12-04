using UnityEngine;

/// <summary>
/// Gimmick(�C�x���g)�̓��e���L�q(�����A���΁A���o�[�A�G���x�[�^�[�A�����J���ATimeLine���s��)
/// �ʒm����������Gimmick�������Ă���C�x���g�����s����
/// �C�x���g�����s���ꂽ���Z�[�u�����s����(DataSave.cs�Ŏ��s)?
/// </summary>
public abstract class GimmickController : MonoBehaviour
{
    [Header("�̉��֘A")]
    [Tooltip("�e�X�g�p�̑̉�")]
    [SerializeField, Range(0f, 40f)] private float _testTemp = 20f;
    [Tooltip("�ō��̉�")]
    [SerializeField, Range(0f, 40f)] private float _maxTemp = 35f;
    [Tooltip("�Œ�̉�")]
    [SerializeField, Range(0f, 10f)] private float _minTemp = 10f;

    /// <summary> �X�e�[�W���̂����̃G���A(�M�~�b�N)���N���A������
    ///           �N���A�����^�C�~���O��true�ɂ��āA�f�[�^�Z�[�u���s�� </summary>
    public bool AreaCheck { get; set; }
    /// <summary> Player�����o�[�ɐڐG������ </summary>
    public bool IsLever { get; set; }
    /// <summary> ����(���΂ɐG���Ƒ̉��㏸) </summary>
    public bool IsTorch { get; set; }
    /// <summary> �̉��m�F
    ///          (�̉����[���ɉ񕜂��Ă��A���΂ɐG��Ă���Ԃ͑̉���������Ȃ��悤��) </summary>
    public bool IsWarm { get; set; }
    /// <summary> ���o�[�̃I�u�W�F�N�g </summary>
    public GameObject Lever { get; set; }

    //IGimmickEvent -> IsPlayAnimation { get; }
    public bool IsPlayAnimation => throw new System.NotImplementedException();

    private void Update()
    {
        //���΂ɐڐG���Ă���
        if (IsTorch == true)
        {
            //�����ŁA�̉����㏸��������̂��Ăяo��
            //(�ȉ��̊֐��̓e�X�g�p)
            Torch();
        }
        //���o�[�ɐڐG���Ă���
        else if (IsLever == true)
        {
            //�����ŁA���o�[�̃M�~�b�N�ɂ�鏈�����Ăяo��
            //(�ȉ��̊֐��̓e�X�g�p)
            LeverMove();
        }
        //���΂ɐڐG���Ă��Ȃ��Ԃ͑̉����ቺ����(��)
        else if (IsTorch == false && IsWarm == false && IsLever == false)
        {
            _testTemp -= Time.deltaTime;
            if (_testTemp < _minTemp)
            {
                _testTemp = _minTemp;
            }
        }
    }

    /// <summary>
    /// Torch...���������΂ɐG��Ă���ԑ̉����������㏸����
    /// </summary>
    public void Torch()
    {
        //���e�X�g�p
        //���Ԍo�߂ɍ��킹�đ̉����㏸����(�����ۂɑ̉����㏸�����鏈���́APlayer�̕��ŋL�q)
        _testTemp += Time.deltaTime;
        //_maxTemp�܂ŏオ�����炻���Ŏ~�߂�
        if (_testTemp > _maxTemp)
        {
            _testTemp = _maxTemp;
            IsTorch = false;
            IsWarm = true;
            Debug.Log("warm enough");
        }
    }

    /// <summary>
    /// ���o�[�𓮂��������Ƃɂ�鏈��(�����J���A�G���x�[�^�[�㏸��)
    /// </summary>
    public void LeverMove()
    {
        //���e�X�g�p�ł�
        Debug.Log("���o�[�ɂ��C�x���g���s��...");
    }
}
