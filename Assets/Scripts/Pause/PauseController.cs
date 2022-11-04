using UnityEngine;

public class PauseController : MonoBehaviour
{
    /// <summary>
    /// ゲームがポーズ中であるかを表す変数
    /// </summary>
    private bool _isPause = false;

    private void Start()
    {
        PauseManager.Instance.AddPauseDebug();
    }

    private void Update()
    {
        ///ボタンが押されたらポーズを実行
        if (Input.GetKeyDown(KeyCode.P)) //ここの押されるボタンは後で変更
        {
            
            if (!_isPause)
            {
                //ポーズ中でないならPauseの処理を実行
                PauseManager.Instance.OnPause?.Invoke();
            }
            else
            {
                ////ポーズ中ならResumeの処理を実行
                PauseManager.Instance.OnResume?.Invoke();
            }
            
            _isPause = !_isPause;
        }
    }
}
