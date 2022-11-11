using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimentionCharactor : MonoBehaviour
{
    private void Start()
    {
        //ƒQ[ƒ€ŠJn‚Ì‚İDimentionManager‚É©•ª‚ğ“o˜^‚·‚é
        DimentionManager.Instance.DimentionCharactorHolder.Add(gameObject);
    }
}
