using UnityEngine;

/// <summary>
/// Gimmick(イベント)の内容を記述(松明、焚火、レバー、エレベーター、扉が開く、TimeLine実行等)
/// 通知が入ったらGimmickが持っているイベントを実行する
/// イベントが実行された時セーブを実行する(DataSave.csで実行)?
/// </summary>
public abstract class GimmickController : MonoBehaviour
{
    [Tooltip("いくつのエリア(ギミック)をクリアしたか")]
    private int _areaCheck = 0;
    [Tooltip("最高体温")]
    [SerializeField, Range(10.0f, 40.0f)] private float _maxTemp = 37.0f;
    [Tooltip("テスト用の体温")]
    [SerializeField, Range(10.0f, 40.0f)] private float _testTemp = 20.0f;
    [Tooltip("レバーを動かす(ドアや、エレベーター)")]
    private bool _isLever = false;
    [Tooltip("松明(焚火に触れると体温上昇)")]
    private bool _isTorch = false;
    [Tooltip("体温確認(体温が回復したら、Torch()をすぐに抜けるため)")]
    private bool _isWarm = false;
    public int AreaCheck { get => _areaCheck; set => _areaCheck = value; }
    /// <summary> Playerがレバーに接触したか </summary>
    public bool IsLever { get => _isLever; set => _isLever = value; }
    /// <summary> 松明(焚火に触れると体温上昇) </summary>
    public bool IsTorch { get => _isTorch; set => _isTorch = value; }
    /// <summary> 体温確認 </summary>
    public bool IsWarm { get => _isWarm; set => _isWarm = value; }

    private void Update()
    {
        if (IsTorch == true)
        {
            //ここで、体温を上昇させるものを呼び出す
            //(以下の関数はテスト用)
            Torch();
        }
        //焚火に接触していない間は体温が低下する
        else if (IsTorch == false && IsWarm == false)
        {
            _testTemp -= Time.deltaTime;
        }
    }

    public void Clear()
    {
        //EventManagerにクリアされたことを通知し、Gimmickが持っているイベントを実行
        //ex. エレベーターが動く、TimeLine等
        if (IsLever == true)
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
            IsTorch = false;
            IsWarm = true;
            Debug.Log("充分に暖まりました");
        }
    }
}
