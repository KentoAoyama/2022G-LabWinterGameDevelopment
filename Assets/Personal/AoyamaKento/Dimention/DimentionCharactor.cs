using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimentionCharactor : MonoBehaviour
{
    void Start()
    {
        //ゲーム開始時のみDimentionManagerに自分を登録する
        DimentionManager.Instance.DimentionCharactorHolder.Add(gameObject);
    }
}
