using System;
using UnityEngine;

[System.Serializable]
public class PlayerDimensionChanger
{
    public void Update(string changeButton)
    {
        if (Input.GetButtonDown(changeButton))
        {
            DimensionChange();
        }
    }
    private void DimensionChange()
    {
        // ここにDimensionManagerに3D,2Dを切り替える命令を記述する。
    }
}