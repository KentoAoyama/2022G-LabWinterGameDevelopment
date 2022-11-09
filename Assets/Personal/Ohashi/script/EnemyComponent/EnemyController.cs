using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyMove _enemyMove;

    void Start()
    {
        _enemyMove = GetComponent<EnemyMove>();
    }
    void Update()
    {
        _enemyMove.Move();
    }
}
