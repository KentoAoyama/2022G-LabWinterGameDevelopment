using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimentionCharactor : MonoBehaviour
{
    private void Start()
    {
        //�Q�[���J�n���̂�DimentionManager�Ɏ�����o�^����
        DimentionManager.Instance.DimentionCharactorHolder.Add(gameObject);
    }
}
