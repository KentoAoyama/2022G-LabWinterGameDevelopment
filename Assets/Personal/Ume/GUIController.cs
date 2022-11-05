using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GUIController : MonoBehaviour
{
    //Playerパラメータの代わり
    [SerializeField] LifeSender lifeSender;
    //HPゲージ
    [SerializeField] PlayerGuage playerGuage;


    void Start()
    {
        lifeSender.PlayerHP.Subscribe(x =>
        {
            playerGuage.SetValues((float)x / lifeSender.MaxHp);
        }).AddTo(this);
        
    }
}
