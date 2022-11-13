using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController3D : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform = default;
    [SerializeField] private EnemyMove3D _enemyMove = default;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _enemyMove.SetBase(transform, _playerTransform);
        _enemyMove.Set3D(_rb);
    }
    private void Update()
    {
        _enemyMove.Move();
    }
}
