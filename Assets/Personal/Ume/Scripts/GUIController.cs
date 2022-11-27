using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GUIController : MonoBehaviour
{
    //Player�p�����[�^�̑���
    [SerializeField] LifeSender lifeSender;
    [SerializeField] TempSender tempSender;
    //HP�Q�[�W
    [SerializeField] PlayerGuage hpBar;
    [SerializeField] PlayerGuage temperatureBar;


    void Start()
    {
        lifeSender.PlayerHP.Subscribe(x =>
        {
            hpBar.SetValues(1-(float)x / lifeSender.MaxHp);
        }).AddTo(this);

        tempSender.PlayerTemp.Subscribe(x =>
        {
            temperatureBar.SetValues(1 - (float)x / tempSender.MaxTemperature);
        }).AddTo(this);
    }
}
