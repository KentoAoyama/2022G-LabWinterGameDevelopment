using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimentionTest : MonoBehaviour
{
    [SerializeField] DimentionController _dimentionController;
    [InputName, SerializeField] string _inputName;

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown(_inputName))
        {
            _dimentionController.DimentionChange();
        }
    }
}
