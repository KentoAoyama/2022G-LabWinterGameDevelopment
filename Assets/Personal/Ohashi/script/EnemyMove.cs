using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤーの座標")] private Transform _player;

    /// <summary>
    /// playerとenemyのX軸の二点間の差で距離を測る
    /// </summary>
    private void PlayerSearch()
    {
        float player = _player.position.x - transform.position.x;
    }
}
