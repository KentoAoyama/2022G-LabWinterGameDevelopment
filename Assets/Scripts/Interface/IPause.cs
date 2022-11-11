using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPause
{
    /// <summary>
    /// IPauseによって実装される、ポーズを行った際に実行されるメソッド
    /// </summary>
    public void Pause();

    /// <summary>
    /// IPauseによって実装される、ポーズを解除した際に実行されるメソッド
    /// </summary>
    public void Resume();
}

