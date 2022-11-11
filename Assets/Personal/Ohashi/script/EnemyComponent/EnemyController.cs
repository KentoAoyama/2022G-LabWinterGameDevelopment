using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyMove _enemyMove;
    private Rigidbody _rb;
    private Rigidbody2D _rb2D;

    void Start()
    {
        _enemyMove = GetComponent<EnemyMove>();
    }
    void Update()
    {
        _enemyMove.Move(_rb, _rb2D);
    }
}
