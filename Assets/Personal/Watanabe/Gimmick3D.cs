using UnityEngine;

/// <summary>
/// 3Dギミックのトリガー判定
/// </summary>
public class Gimmick3D : GimmickController
{
    private void OnTriggerEnter(Collider other)
    {
        //レバーに触れた場合↓
        if (other.gameObject.CompareTag("Lever"))
        {
            IsLever = true;
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
        if (other.gameObject.CompareTag("Lever"))
        {
            IsLever = false;
        }
        //Playerが焚火から離れた時にGimmickを終了する
        else if (other.gameObject.CompareTag("Bonfire"))
        {
            IsTorch = false;
            IsWarm = false;
        }
    }
}
