using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GUIController : MonoBehaviour
{
    //Player�p�����[�^�̑���
    [SerializeField] LifeSender lifeSender;
    //HP�Q�[�W
    [SerializeField] PlayerGuage playerGuage;


    void Start()
    {
        lifeSender.PlayerHP.Subscribe(x =>
        {
            playerGuage.SetValues((float)x / lifeSender.MaxHp);
        }).AddTo(this);
        
    }
}
