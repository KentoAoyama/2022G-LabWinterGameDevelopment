using UnityEngine;

/// <summary>
/// Dimention�̑Ώۂ�
/// </summary>
public class DimentionObject : MonoBehaviour
{
    private void Start()
    {
        DimentionManager.Instance.DimentionObjectHolder.Add(gameObject);
    }
}
