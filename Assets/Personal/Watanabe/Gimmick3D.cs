using UnityEngine;

/// <summary>
/// 3D�M�~�b�N�̃g���K�[����
/// </summary>
public class Gimmick3D : GimmickController
{
    private void OnTriggerEnter(Collider other)
    {
        //���o�[�ɐG�ꂽ�ꍇ��
        if (other.gameObject.CompareTag("Lever"))
        {
            IsLever = true;
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
        if (other.gameObject.CompareTag("Lever"))
        {
            IsLever = false;
        }
        //Player�����΂��痣�ꂽ����Gimmick���I������
        else if (other.gameObject.CompareTag("Bonfire"))
        {
            IsTorch = false;
            IsWarm = false;
        }
    }
}
