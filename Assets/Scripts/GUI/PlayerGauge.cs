using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerGauge : MonoBehaviour
{
    [SerializeField] float sliderDownTime = 1f;
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    /// <summary>Viewとして扱えるようにするため、Presenterから参照可能にする</summary>
    /// <param name="value">ステータスの現在の値</param>
    public void SetValues(float value)
    {
        DOTween.To(() => slider.value,   
            n => slider.value = n,       
            value,                        
            duration: sliderDownTime);
    }
}
