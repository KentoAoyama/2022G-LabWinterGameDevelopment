using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_InputSystem
{
    #region Singleton
    private static Input_InputSystem _instance = new Input_InputSystem();
    public static Input_InputSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"Error! Please correct!");
            }
            return _instance;
        }
    }
    private Input_InputSystem() { }
    #endregion
}