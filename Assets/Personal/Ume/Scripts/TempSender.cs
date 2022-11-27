using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TempSender : MonoBehaviour
{
    const int temperature = 100; //HP�̒l���`
    int _maxTemperature = temperature;
    /// <summary>�ő�HP</summary>
    public int MaxTemperature => _maxTemperature;

    /// <summary>ReactiveProperty�Ƃ��ĎQ�Ɖ\�ɂ���</summary>    //Presenter����̃A�N�Z�X���\�ɂ��邽��
    public IReadOnlyReactiveProperty<int> PlayerTemp => _playerTemp;
    //���J���邱�ƂŁAModel�̓�����Ԃ��ω������Ƃ���
    readonly IntReactiveProperty _playerTemp = new(temperature);              //���ꂪObservable�Ƃ��ĊO���ɒʒm�ł���

    bool _isDamage;
    /// <summary>�_���[�W���󂯂����Ƃ�\���v���p�e�B</summary>
    public bool IsDamage => _isDamage;


    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddDamage(10);
        }

        else if (Input.GetKeyDown(KeyCode.Z))
        {
            AddDamage(-10);
        }
    }

    public void AddDamage(int damage)
    {
        _playerTemp.Value -= damage;
    }


    void OnDestroy()
    {
        //����Ȃ��Ȃ�����K�X�j������
        _playerTemp.Dispose();
    }
}
