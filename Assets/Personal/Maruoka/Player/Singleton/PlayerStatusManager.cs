using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager
{
    #region Singleton
    private static PlayerStatusManager _instance = new PlayerStatusManager();
    public static PlayerStatusManager Instance
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
    private PlayerStatusManager(){}
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