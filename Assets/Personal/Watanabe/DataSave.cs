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

    /// <summary>
    /// �t�@�C���ւ̕ۑ�(�o��)
    /// </summary>
    public void Save()
    {
        StreamWriter writer;
        //string json = JsonUtility.ToJson();

        //���̃^�C�~���O�Ńf�[�^�Z�[�u���s��
        if (_gimmick.AreaCheck == true)
        {
            writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
            //writer.Write(json);
            writer.Flush();
            writer.Close();
            Debug.Log("�M�~�b�N���N���A�������߁A�f�[�^�Z�[�u���s���܂�");
            _gimmick.AreaCheck = false;
        }
    }

    /// <summary>
    /// �t�@�C������f�[�^��ǂݍ���
    /// </summary>
    public void Load()
    {
        string data = "";
        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/savedata.json");
        data = reader.ReadToEnd();
        reader.Close();
    }
}
