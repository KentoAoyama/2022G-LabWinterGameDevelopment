using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus
{
    #region Singleton
    private static PlayerStatus _instance = new PlayerStatus();
    public static PlayerStatus Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError($"Error! Please correct!");
            }
            return _instance;
        }
    }
    private PlayerStatus(){}
    #endregion

    #region Member Variables
    #endregion

    #region Properties
    #endregion

    #region Events
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}