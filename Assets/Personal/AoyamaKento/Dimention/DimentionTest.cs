using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimentionTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DimentionManager.Instance.DimentionChange();
        }
    }
}
