using UnityEngine;
using System.IO;

/// <summary>
/// データセーブ(Gimmickが実行されたタイミングで実行する)
/// (GameManagerのようにゲーム内に1つであるべき?)
/// </summary>
public class DataSave : MonoBehaviour
{
    //保存しておく必要があるデータ一覧↓
    //1,Playerの位置(Position)
    //2,ゲームの進行状況(ステージ内のギミック、エリアをどこまで攻略したか)

    [SerializeField] GimmickController _gimmick;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        //このタイミングでデータセーブを行う
        if (_gimmick.AreaCheck == true)
        {
            Debug.Log("ギミックをクリアしたため、データセーブを行います");
            _gimmick.AreaCheck = false;
        }
    }
}
