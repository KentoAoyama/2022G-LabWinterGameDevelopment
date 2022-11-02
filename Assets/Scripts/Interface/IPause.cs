using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPause
{
    /// <summary>
    /// PauseManagerにPauseResumeを登録するためのメソッド
    /// これをStartで呼び出す
    /// </summary>
    protected void SetPauseResume();

    /// <summary>
    /// PauseManagerからPauseResumeを削除するためのメソッド
    /// これをOnDisableで呼び出す
    /// </summary>
    protected void RemovePauseResume();

    /// <summary>
    /// IPauseによって実装される、ポーズを行った際に実行されるメソッド
    /// </summary>
    public void Pause();

    /// <summary>
    /// IPauseによって実装される、ポーズを解除した際に実行されるメソッド
    /// </summary>
    public void Resume();
}

