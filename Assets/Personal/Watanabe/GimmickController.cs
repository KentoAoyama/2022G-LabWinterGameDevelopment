using UnityEngine;

/// <summary>
/// Gimmick(イベント)の内容を記述(松明、焚火、レバー、エレベーター、扉が開く、TimeLine実行等)
/// 通知が入ったらGimmickが持っているイベントを実行する
/// イベントが実行された時セーブを実行する(DataSave.csで実行)?
/// </summary>
public abstract class GimmickController : MonoBehaviour
{
    [Header("体温関連")]
    [Tooltip("テスト用の体温")]
    [SerializeField, Range(0f, 40f)] private float _testTemp = 20f;
    [Tooltip("最高体温")]
    [SerializeField, Range(0f, 40f)] private float _maxTemp = 35f;
    [Tooltip("最低体温")]
    [SerializeField, Range(0f, 10f)] private float _minTemp = 10f;

    /// <summary> ステージ内のいくつのエリア(ギミック)をクリアしたか
    ///           クリアしたタイミングでtrueにして、データセーブを行う </summary>
    public bool AreaCheck { get; set; }
    /// <summary> Playerがレバーに接触したか </summary>
    public bool IsLever { get; set; }
    /// <summary> 松明(焚火に触れると体温上昇) </summary>
    public bool IsTorch { get; set; }
    /// <summary> 体温確認
    ///          (体温が充分に回復しても、焚火に触れている間は体温が下がらないように) </summary>
    public bool IsWarm { get; set; }
    /// <summary> レバーのオブジェクト </summary>
    public GameObject Lever { get; set; }

    //IGimmickEvent -> IsPlayAnimation { get; }
    public bool IsPlayAnimation => throw new System.NotImplementedException();

    private void Update()
    {
        //焚火に接触している
        if (IsTorch == true)
        {
            //ここで、体温を上昇させるものを呼び出す
            //(以下の関数はテスト用)
            Torch();
        }
        //レバーに接触している
        else if (IsLever == true)
        {
            //ここで、レバーのギミックによる処理を呼び出す
            //(以下の関数はテスト用)
            LeverMove();
        }
        //焚火に接触していない間は体温が低下する(仮)
        else if (IsTorch == false && IsWarm == false && IsLever == false)
        {
            _testTemp -= Time.deltaTime;
            if (_testTemp < _minTemp)
            {
                _testTemp = _minTemp;
            }
        }
    }

    /// <summary>
    /// Torch...松明が焚火に触れている間体温が少しずつ上昇する
    /// </summary>
    public void Torch()
    {
        //↓テスト用
        //時間経過に合わせて体温が上昇する(※実際に体温を上昇させる処理は、Playerの方で記述)
        _testTemp += Time.deltaTime;
        //_maxTempまで上がったらそこで止める
        if (_testTemp > _maxTemp)
        {
            _testTemp = _maxTemp;
            IsTorch = false;
            IsWarm = true;
            Debug.Log("warm enough");
        }
    }

    /// <summary>
    /// レバーを動かしたことによる処理(扉を開く、エレベーター上昇等)
    /// </summary>
    public void LeverMove()
    {
        //↓テスト用です
        Debug.Log("レバーによるイベント実行中...");
    }
}
