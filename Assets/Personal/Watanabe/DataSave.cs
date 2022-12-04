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

    /// <summary>
    /// ファイルへの保存(出力)
    /// </summary>
    public void Save()
    {
        StreamWriter writer;
        //string json = JsonUtility.ToJson();

        //このタイミングでデータセーブを行う
        if (_gimmick.AreaCheck == true)
        {
            writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
            //writer.Write(json);
            writer.Flush();
            writer.Close();
            Debug.Log("ギミックをクリアしたため、データセーブを行います");
            _gimmick.AreaCheck = false;
        }
    }

    /// <summary>
    /// ファイルからデータを読み込む
    /// </summary>
    public void Load()
    {
        string data = "";
        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/savedata.json");
        data = reader.ReadToEnd();
        reader.Close();
    }
}
