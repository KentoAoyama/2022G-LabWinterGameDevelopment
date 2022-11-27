using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerGuage : MonoBehaviour
{
    [SerializeField] float sliderDownTime = 1f;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>View�Ƃ��Ĉ�����悤�ɂ��邽�߁APresenter����Q�Ɖ\�ɂ���</summary>
    /// <param name="value">�X�e�[�^�X�̌��݂̒l</param>
    public void SetValues(float value)
    {
        DOTween.To(() => slider.value,   
            n => slider.value = n,       
            value,                        
            duration: sliderDownTime);
    }
}
