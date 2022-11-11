using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [Header("Ú’nŠÖ˜A")]
    [SerializeField]
    private Color _gizmosColor = Color.red;
    [SerializeField]
    private Vector3 _offset = default;
    [SerializeField]
    private Vector3 _size = default;
    [SerializeField]
    private LayerMask _layerMask = default;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawCube(transform.position + _offset, _size);
    }

    public bool IsGround()
    {
        var colliders =
            Physics2D.OverlapBoxAll(
                transform.position + _offset,
                _size, 0.0f, _layerMask);
        return colliders.Length > 0;
    }
}