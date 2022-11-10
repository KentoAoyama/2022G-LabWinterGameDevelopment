using UnityEngine;

/// <summary>
/// 2D�M�~�b�N�̃g���K�[����
/// </summary>
public class Gimmick2D : GimmickController
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        //���o�[�ɐG�ꂽ�ꍇ��
        if (col.gameObject.CompareTag("Lever"))
        {
            IsLever = true;
        }
        //����(Bonfire)�ƐڐG�����ꍇ��
        else if (col.gameObject.CompareTag("Bonfire"))
        {
            IsTorch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //Player�����o�[���痣�ꂽ����Gimmick���I������
        if (col.gameObject.CompareTag("Lever"))
        {
            IsLever = false;
        }
        //Player�����΂��痣�ꂽ����Gimmick���I������
        else if (col.gameObject.CompareTag("Bonfire"))
        {
            IsTorch = false;
            IsWarm = false;
        }
    }
}
