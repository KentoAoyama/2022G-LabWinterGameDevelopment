using UnityEngine;

/// <summary>
/// 2D�M�~�b�N�̃g���K�[����
/// </summary>
public class Gimmick2D : GimmickController
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        //���΂ƐڐG�����ꍇ��
        if (col.gameObject.CompareTag("Bonfire"))
        {
            IsTorch = true;
        }
        //���o�[�ɐG�ꂽ�ꍇ��
        else if (col.gameObject.CompareTag("Lever"))
        {
            IsLever = true;
            Lever = col.gameObject;
            Debug.Log("touch lever");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //Player�����΂��痣�ꂽ����Gimmick���I������
        if (col.gameObject.CompareTag("Bonfire"))
        {
            IsTorch = false;
            IsWarm = false;
        }
        //Player�����o�[���痣�ꂽ����Gimmick���I������
        else if (col.gameObject.CompareTag("Lever"))
        {
            IsLever = false;
            Lever = null;
            Debug.Log("exit lever");
        }
    }
}
