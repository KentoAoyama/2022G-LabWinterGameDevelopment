using UnityEngine;

/// <summary>
/// 2Dギミックのトリガー判定
/// </summary>
public class Gimmick2D : GimmickController
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        //レバーに触れた場合↓
        if (col.gameObject.CompareTag("Lever"))
        {
            IsLever = true;
        }
        //焚火(Bonfire)と接触した場合↓
        else if (col.gameObject.CompareTag("Bonfire"))
        {
            IsTorch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //Playerがレバーから離れた時にGimmickを終了する
        if (col.gameObject.CompareTag("Lever"))
        {
            IsLever = false;
        }
        //Playerが焚火から離れた時にGimmickを終了する
        else if (col.gameObject.CompareTag("Bonfire"))
        {
            IsTorch = false;
            IsWarm = false;
        }
    }
}
