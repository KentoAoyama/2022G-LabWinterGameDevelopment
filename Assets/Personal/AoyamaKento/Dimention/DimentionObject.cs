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

    private void OnDisable()
    {
        //DimentionManagerから自分を削除する
        DimentionManager.Instance.DimentionObjectHolder.Remove(gameObject);
    }
}
