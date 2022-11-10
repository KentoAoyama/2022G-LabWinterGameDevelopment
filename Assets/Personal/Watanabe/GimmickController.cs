using UnityEngine;

/// <summary>
/// Gimmick(�C�x���g)�̓��e���L�q(�����A���΁A���o�[�A�G���x�[�^�[�A�����J���ATimeLine���s��)
/// �ʒm����������Gimmick�������Ă���C�x���g�����s����
/// �C�x���g�����s���ꂽ���Z�[�u�����s����(DataSave.cs�Ŏ��s)?
/// </summary>
public abstract class GimmickController : MonoBehaviour
{
    [Tooltip("�����̃G���A(�M�~�b�N)���N���A������")]
    private int _areaCheck = 0;
    [Tooltip("�ō��̉�")]
    [SerializeField, Range(10.0f, 40.0f)] private float _maxTemp = 37.0f;
    [Tooltip("�e�X�g�p�̑̉�")]
    [SerializeField, Range(10.0f, 40.0f)] private float _testTemp = 20.0f;
    [Tooltip("���o�[�𓮂���(�h�A��A�G���x�[�^�[)")]
    private bool _isLever = false;
    [Tooltip("����(���΂ɐG���Ƒ̉��㏸)")]
    private bool _isTorch = false;
    [Tooltip("�̉��m�F(�̉����񕜂�����ATorch()�������ɔ����邽��)")]
    private bool _isWarm = false;
    public int AreaCheck { get => _areaCheck; set => _areaCheck = value; }
    /// <summary> Player�����o�[�ɐڐG������ </summary>
    public bool IsLever { get => _isLever; set => _isLever = value; }
    /// <summary> ����(���΂ɐG���Ƒ̉��㏸) </summary>
    public bool IsTorch { get => _isTorch; set => _isTorch = value; }
    /// <summary> �̉��m�F </summary>
    public bool IsWarm { get => _isWarm; set => _isWarm = value; }

    private void Update()
    {
        if (IsTorch == true)
        {
            //�����ŁA�̉����㏸��������̂��Ăяo��
            //(�ȉ��̊֐��̓e�X�g�p)
            Torch();
        }
        //���΂ɐڐG���Ă��Ȃ��Ԃ͑̉����ቺ����
        else if (IsTorch == false && IsWarm == false)
        {
            _testTemp -= Time.deltaTime;
        }
    }

    public void Clear()
    {
        //EventManager�ɃN���A���ꂽ���Ƃ�ʒm���AGimmick�������Ă���C�x���g�����s
        //ex. �G���x�[�^�[�������ATimeLine��
        if (IsLever == true)
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
            IsTorch = false;
            IsWarm = true;
            Debug.Log("�[���ɒg�܂�܂���");
        }
    }
}
