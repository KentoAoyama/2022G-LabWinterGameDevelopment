using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LifeSender : MonoBehaviour
{
    const int Hp = 100; //HPの値を定義
    int _maxHp = Hp;
    /// <summary>最大HP</summary>
    public int MaxHp => _maxHp;

    /// <summary>ReactivePropertyとして参照可能にする</summary>    //Presenterからのアクセスを可能にするため
    public IReadOnlyReactiveProperty<int> PlayerHP => _playerHP;
    //公開することで、Modelの内部状態が変化したときに
    readonly IntReactiveProperty _playerHP = new(Hp);              //それがObservableとして外部に通知できる

    bool _isDamage;
    /// <summary>ダメージを受けたことを表すプロパティ</summary>
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
        //いらなくなったら適宜破棄する
        _playerHP.Dispose();
    }
}
