using UnityEngine;
using System.IO;

/// <summary>
/// �f�[�^�Z�[�u(Gimmick�����s���ꂽ�^�C�~���O�Ŏ��s����)
/// (GameManager�̂悤�ɃQ�[������1�ł���ׂ�?)
/// </summary>
public class DataSave : MonoBehaviour
{
    //�ۑ����Ă����K�v������f�[�^�ꗗ��
    //1,Player�̈ʒu(Position)
    //2,�Q�[���̐i�s��(�X�e�[�W���̃M�~�b�N�A�G���A���ǂ��܂ōU��������)

    [SerializeField] GimmickController _gimmick;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        //���̃^�C�~���O�Ńf�[�^�Z�[�u���s��
        if (_gimmick.AreaCheck == true)
        {
            Debug.Log("�M�~�b�N���N���A�������߁A�f�[�^�Z�[�u���s���܂�");
            _gimmick.AreaCheck = false;
        }
    }
}
