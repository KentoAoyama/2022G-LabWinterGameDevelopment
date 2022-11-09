using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimentionTest : MonoBehaviour
{
    [SerializeField] DimentionController _dimentionController;
    [InputName, SerializeField] string _inputName;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(_inputName))
        {
            Debug.Log("OK");
            _dimentionController.DimentionChange();
        }
    }
}
