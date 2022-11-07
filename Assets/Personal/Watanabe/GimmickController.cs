using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gimmick(イベント)の内容を記述(松明、焚火、レバー、エレベーター、扉が開く、TimeLine実行等)
/// 通知が入ったらGimmickが持っているイベントを実行する
/// イベントが何か実行された時セーブを実行する(DataSave.csで実行)?
/// </summary>
public class GimmickController : MonoBehaviour
{
    [Tooltip("最高体温")]
    [SerializeField] private float _maxTemp = 37.0f;
    [Tooltip("テスト用の体温")]
    [SerializeField, Range(10.0f, 40.0f)] private float _testTemp = 10.0f;
    [Tooltip("松明(焚火に触れると体温上昇)")]
    [SerializeField] private bool _isTorch = false;
    /// <summary> Playerがレバーに接触した際のフラグ </summary>
    public bool IsTouchLever { get; set; }
    /// <summary> 松明(焚火に触れると体温上昇) </summary>
    public bool IsTorch { get => _isTorch; set => _isTorch = value; }

    private void Update()
    {
        if (IsTorch == true)
        {
            //ここで、体温を上昇させるものを呼び出す(以下の関数はテスト用)
            Torch();
        }
    }

    public void Clear()
    {
        //EventManagerにクリアされたことを通知し、Gimmickが持っているイベントを実行
        //ex. エレベーターが動く、TimeLine等
        if (IsTouchLever == true)
        {
            //扉を開く、エレベーター上昇の処理(Animation等)
        }
    }

    /// <summary>
    /// Torch...松明が焚火に触れている間体温が少しずつ上昇する
    /// </summary>
    public void Torch()
    {
        //時間経過に合わせて体温が上昇する(実際に体温を上昇させる処理は、Playerの方で記述)
        _testTemp += Time.deltaTime;
        //一定の体温まで上がったらそこで止める
        if (_testTemp > _maxTemp)
        {
            _testTemp = _maxTemp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //レバーに触れた場合↓
        if (other.gameObject.CompareTag("Lever"))
        {
            IsTouchLever = true;
        }
        //焚火(Bonfire)と接触した場合↓
        else if (other.gameObject.CompareTag("Bonfire"))
        {
            IsTorch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Playerがレバーから離れた時にGimmickを終了する
        IsTouchLever = false;
        //Playerが焚火から離れた時にGimmickを終了する
        IsTorch = false;
    }
}
