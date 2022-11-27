using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwitchable
{
    public bool IsActive { get; }

    /// <summary> �M�~�b�N���J�n���鏈�� </summary>
    public void Active();
    /// <summary> �M�~�b�N���I�����鏈�� </summary>
    public void InActive();
}
