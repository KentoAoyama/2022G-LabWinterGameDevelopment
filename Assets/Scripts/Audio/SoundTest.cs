using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    [SerializeField] SoundType soundType;
    [SerializeField] int soundNum = 0;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SoundManager.Instance.AudioPlay(soundType, soundNum);
        }
    }
}
