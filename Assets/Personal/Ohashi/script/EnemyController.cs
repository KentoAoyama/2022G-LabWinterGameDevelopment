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
        _enemyMove.PlayerSearch();
        _enemyMove.Move();
        Debug.Log(_enemyMove.PlayerSearch());
    }
}
