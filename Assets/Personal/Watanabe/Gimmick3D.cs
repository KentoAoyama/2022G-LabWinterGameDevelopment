using UnityEngine;

/// <summary>
/// 3Dギミックのトリガー判定
/// </summary>
public class Gimmick3D : GimmickController
{
    private void OnTriggerEnter(Collider other)
    {
        //焚火(Bonfire)と接触した場合↓
        if (other.gameObject.CompareTag("Bonfire"))
        {
            IsTorch = true;
        }
        //レバーに触れた場合↓
        else if (other.gameObject.CompareTag("Lever"))
        {
            IsLever = true;
            Lever = other.gameObject;
            Debug.Log("touch lever");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Playerが焚火から離れた時にGimmickを終了する
        if (other.gameObject.CompareTag("Bonfire"))
        {
            IsTorch = false;
            IsWarm = false;
        }
        //Playerがレバーから離れた時にGimmickを終了する
        else if (other.gameObject.CompareTag("Lever"))
        {
            IsLever = false;
            Lever = null;
            Debug.Log("exit lever");
        }
    }
}
