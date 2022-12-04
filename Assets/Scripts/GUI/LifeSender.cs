using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LifeSender : MonoBehaviour
{
    const int Hp = 100; //HP�̒l���`
    int _maxHp = Hp;
    /// <summary>�ő�HP</summary>
    public int MaxHp => _maxHp;

    /// <summary>ReactiveProperty�Ƃ��ĎQ�Ɖ\�ɂ���</summary>    //Presenter����̃A�N�Z�X���\�ɂ��邽��
    public IReadOnlyReactiveProperty<int> PlayerHP => _playerHP;
    //���J���邱�ƂŁAModel�̓�����Ԃ��ω������Ƃ���
    readonly IntReactiveProperty _playerHP = new(Hp);              //���ꂪObservable�Ƃ��ĊO���ɒʒm�ł���

    bool _isDamage;
    /// <summary>�_���[�W���󂯂����Ƃ�\���v���p�e�B</summary>
    public bool IsDamage => _isDamage;


    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            AddDamage(10);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            AddDamage(-10);
        }
    }

    public void AddDamage(int damage)
    {
        _playerHP.Value -= damage;
    }


    void OnDestroy()
    {
        //����Ȃ��Ȃ�����K�X�j������
        _playerHP.Dispose();
    }
}
