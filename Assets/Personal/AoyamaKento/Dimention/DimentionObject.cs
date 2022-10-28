using UnityEngine;

/// <summary>
/// Dimention‚Ì‘ÎÛ‚É
/// </summary>
public class DimentionObject : MonoBehaviour
{
    private void Start()
    {
        DimentionManager.Instance.DimentionObjectHolder.Add(gameObject);
    }
}
