using System;
using UnityEngine;

[System.Serializable]
public class Damage2D : PlayerDamage
{
    #region Member Variables
    private Rigidbody2D _rb2D = default;
    #endregion

    #region Public Methods
    public override void OnDamage(int value)
    {

    }
    #endregion

    #region Private Methods
    #endregion
}