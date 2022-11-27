using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TempSender : MonoBehaviour
{
    const int temperature = 100; //HPの値を定義
    int _maxTemperature = temperature;
    /// <summary>最大HP</summary>
    public int MaxTemperature => _maxTemperature;

    /// <summary>ReactivePropertyとして参照可能にする</summary>    //Presenterからのアクセスを可能にするため
    public IReadOnlyReactiveProperty<int> PlayerTemp => _playerTemp;
    //公開することで、Modelの内部状態が変化したときに
    readonly IntReactiveProperty _playerTemp = new(temperature);              //それがObservableとして外部に通知できる

    bool _isDamage;
    /// <summary>ダメージを受けたことを表すプロパティ</summary>
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
        //いらなくなったら適宜破棄する
        _playerTemp.Dispose();
    }
}
