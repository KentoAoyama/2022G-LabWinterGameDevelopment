using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrip : MonoBehaviour
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
        var x = Input_InputManager.Instance.GetAxisRaw(_horizontalButtonName);

        if (x == 0) return;

        var dir = _defaultScale;
        dir.x *= x;
        transform.localScale = dir;
    }
}
