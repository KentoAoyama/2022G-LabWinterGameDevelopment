using System;
using UnityEngine;

[System.Serializable]
public class Input_InputManager : SelfMadeInput
{
    public override bool GetInputDown(string inputName)
    {
        return Input.GetButtonDown(inputName);
    }

    public override bool GetInput(string inputName)
    {
        return Input.GetButton(inputName);
    }

    public override bool GetInputUp(string inputName)
    {
        return Input.GetButtonUp(inputName);
    }

    public override float GetAxisRaw(string inputName)
    {
        return Input.GetAxisRaw(inputName);
    }
}