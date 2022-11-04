using UnityEngine;

public class PauseController : MonoBehaviour
{
    /// <summary>
    /// �Q�[�����|�[�Y���ł��邩��\���ϐ�
    /// </summary>
    private bool _isPause = false;

    private void Start()
    {
        PauseManager.Instance.AddPauseDebug();
    }

    private void Update()
    {
        ///�{�^���������ꂽ��|�[�Y�����s
        if (Input.GetKeyDown(KeyCode.P)) //�����̉������{�^���͌�ŕύX
        {
            
            if (!_isPause)
            {
                //�|�[�Y���łȂ��Ȃ�Pause�̏��������s
                PauseManager.Instance.OnPause?.Invoke();
            }
            else
            {
                ////�|�[�Y���Ȃ�Resume�̏��������s
                PauseManager.Instance.OnResume?.Invoke();
            }
            
            _isPause = !_isPause;
        }
    }
}
