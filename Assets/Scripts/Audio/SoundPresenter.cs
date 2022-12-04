using UnityEngine;

/// <summary>
/// SoundManagerにSoundScriptableObjectの参照を渡すためのクラス
/// </summary>
public class SoundPresenter : MonoBehaviour
{
    [Header("サウンドの情報を持つScriptableObject")]
    [SerializeField] SoundScriptableObject _soundScriptableObj;

    private void Awake()
    {       
        if (SoundManager.Instance.SoundScriptable == null)
        {
            SoundManager.Instance.SoundScriptable = _soundScriptableObj;
        }

        //一応削除しておく
        Destroy(gameObject);
    }
}
