using UnityEngine;

/// <summary>
/// Dimention�̑ΏۂɂȂ�I�u�W�F�N�g�ɃA�^�b�`����N���X
/// </summary>
public class DimentionObject : MonoBehaviour
{
    private void Start()
    {
        //DimentionManager�Ɏ�����o�^����
        DimentionManager.Instance.DimentionObjectHolder.Add(gameObject);
    }

    private void OnDisable()
    {
        //DimentionManager���玩�����폜����
        DimentionManager.Instance.DimentionObjectHolder.Remove(gameObject);
    }
}
