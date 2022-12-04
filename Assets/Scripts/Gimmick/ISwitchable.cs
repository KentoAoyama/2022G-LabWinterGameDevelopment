using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwitchable
{
    public bool IsActive { get; }

    /// <summary> ギミックを開始する処理 </summary>
    public void Active();
    /// <summary> ギミックを終了する処理 </summary>
    public void InActive();
}
