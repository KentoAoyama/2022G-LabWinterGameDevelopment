using UnityEngine;

/// <summary>
/// 2Dギミックのトリガー判定
/// </summary>
public class Gimmick2D : GimmickController
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        //焚火と接触した場合↓
        if (col.gameObject.CompareTag("Bonfire"))
        {
            IsTorch = true;
        }
        //レバーに触れた場合↓
        else if (col.gameObject.CompareTag("Lever"))
        {
            IsLever = true;
            Lever = col.gameObject;
            Debug.Log("touch lever");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //Playerが焚火から離れた時にGimmickを終了する
        if (col.gameObject.CompareTag("Bonfire"))
        {
            IsTorch = false;
            IsWarm = false;
        }
        //Playerがレバーから離れた時にGimmickを終了する
        else if (col.gameObject.CompareTag("Lever"))
        {
            IsLever = false;
            Lever = null;
            Debug.Log("exit lever");
        }
    }
}
