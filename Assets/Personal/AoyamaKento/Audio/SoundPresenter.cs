using UnityEngine;

/// <summary>
/// SoundManager��SoundScriptableObject�̎Q�Ƃ�n�����߂̃N���X
/// </summary>
public class SoundPresenter : MonoBehaviour
{
    [Header("�T�E���h�̏�������ScriptableObject")]
    [SerializeField] SoundScriptableObject _soundScriptableObj;

    private void Awake()
    {       
        if (SoundManager.Instance.SoundScriptable == null)
        {
            SoundManager.Instance.SoundScriptable = _soundScriptableObj;
        }

        //�ꉞ�폜���Ă���
        Destroy(gameObject);
    }
}
