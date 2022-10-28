using UnityEngine;

/// <summary>
/// Dimentionの対象になるオブジェクトにアタッチするクラス
/// </summary>
public class DimentionObject : MonoBehaviour
{
    private void Start()
    {
        //DimentionManagerに自分を登録する
        DimentionManager.Instance.DimentionObjectHolder.Add(gameObject);
    }
}
