using System;
using UnityEngine;

[System.Serializable]
public abstract class SelfMadeInput
{
    public abstract bool GetInputDown(string inputName);
    public abstract bool GetInput(string inputName);
    public abstract bool GetInputUp(string inputName);
    public abstract float GetAxisRaw(string inputName);
}