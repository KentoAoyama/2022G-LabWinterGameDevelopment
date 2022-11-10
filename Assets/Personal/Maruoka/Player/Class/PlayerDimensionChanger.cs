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
        // ‚±‚±‚ÉDimensionManager‚É3D,2D‚ğØ‚è‘Ö‚¦‚é–½—ß‚ğ‹Lq‚·‚éB
    }
}