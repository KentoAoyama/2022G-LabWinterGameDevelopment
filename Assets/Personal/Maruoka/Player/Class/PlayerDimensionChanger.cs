using System;
using UnityEngine;

[System.Serializable]
public class PlayerDimensionChanger
{
    public void Detection(string changeButton)
    {
        if (Input.GetButtonDown(changeButton))
        {
            // ここにDimensionManagerに3D,2Dを切り替える命令を記述する。
        }
    }
}