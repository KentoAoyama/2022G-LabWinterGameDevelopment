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
        // ������DimensionManager��3D,2D��؂�ւ��閽�߂��L�q����B
    }
}