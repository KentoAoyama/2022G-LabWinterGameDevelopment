using System;
using UnityEngine;

[System.Serializable]
public class Input_InputManager
{
    #region Singleton
    private static Input_InputManager _instance = new Input_InputManager();
    public static Input_InputManager Instance
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
    private Input_InputManager() { }
    #endregion

    public bool GetInputDown(string inputName)
    {
        return Input.GetButtonDown(inputName);
    }

    public bool GetInput(string inputName)
    {
        return Input.GetButton(inputName);
    }

    public bool GetInputUp(string inputName)
    {
        return Input.GetButtonUp(inputName);
    }

    public float GetAxisRaw(string inputName)
    {
        return Input.GetAxisRaw(inputName);
    }
}