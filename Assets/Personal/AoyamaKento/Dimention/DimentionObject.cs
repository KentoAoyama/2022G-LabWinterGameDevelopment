using UnityEngine;

/// <summary>
/// Dimentionの対象になるオブジェクトにアタッチするクラス
/// </summary>
public class DimentionObject : MonoBehaviour
{
    private void Start()
    {
        DimentionManager.Instance.DimentionObjectHolder.Add(gameObject);
    }
}
