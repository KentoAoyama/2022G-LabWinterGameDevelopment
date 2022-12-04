using UnityEngine;

/// <summary>
/// 3D�M�~�b�N�̃g���K�[����
/// </summary>
public class Gimmick3D : GimmickController
{
    private void OnTriggerEnter(Collider other)
    {
        //����(Bonfire)�ƐڐG�����ꍇ��
        if (other.gameObject.CompareTag("Bonfire"))
        {
            IsTorch = true;
        }
        //���o�[�ɐG�ꂽ�ꍇ��
        else if (other.gameObject.CompareTag("Lever"))
        {
            IsLever = true;
            Lever = other.gameObject;
            Debug.Log("touch lever");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Player�����΂��痣�ꂽ����Gimmick���I������
        if (other.gameObject.CompareTag("Bonfire"))
        {
            IsTorch = false;
            IsWarm = false;
        }
        //Player�����o�[���痣�ꂽ����Gimmick���I������
        else if (other.gameObject.CompareTag("Lever"))
        {
            IsLever = false;
            Lever = null;
            Debug.Log("exit lever");
        }
    }
}
