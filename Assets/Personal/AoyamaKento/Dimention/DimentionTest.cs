using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimentionTest : MonoBehaviour
{
    [SerializeField] DimentionController _dimentionController;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _dimentionController.DimentionChange();
        }
    }
}
