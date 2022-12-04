using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrip3D : MonoBehaviour
{
    [InputName, SerializeField]
    private string _horizontalButtonName = default;

    private Vector3 _defaultScale;

    private void Start()
    {
        _defaultScale = transform.localScale;
    }

    private void Update()
    {
        var z = Input_InputManager.Instance.GetAxisRaw(_horizontalButtonName);

        if (z == 0) return;

        var dir = _defaultScale;
        dir.z *= z;
        transform.localScale = dir;
    }
}
