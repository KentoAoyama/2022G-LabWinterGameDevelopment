using System;
using UnityEngine;

[System.Serializable]
public class PlayerDimensionChanger
{
    public void Detection(string changeButton)
    {
        if (Input.GetButtonDown(changeButton))
        {
            // ������DimensionManager��3D,2D��؂�ւ��閽�߂��L�q����B
        }
    }
}