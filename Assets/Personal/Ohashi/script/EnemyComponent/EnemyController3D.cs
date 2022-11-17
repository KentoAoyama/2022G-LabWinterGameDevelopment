using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController3D : RetainedEnemyBehavior
{
    [SerializeField] private EnemyMove3D _enemyMove = new EnemyMove3D();
    [SerializeField] private EnemyShortAttack3D _enemyShortAttack3D = new EnemyShortAttack3D();
    [SerializeField] private EnemyId _enemyId = EnemyId.Short;

    private ObjectHolderManager _objectHolderManager;
    private Rigidbody _rb;
    

    private enum EnemyId
    {
        Short,
        Long,
    }


    protected override int Id => throw new System.NotImplementedException();

    protected override int Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _objectHolderManager = ObjectHolderManager.Instance;
        _enemyMove.SetBase(transform, _objectHolderManager.PlayerHolder);
        _enemyMove.Set3D(_rb);
        _enemyShortAttack3D.AttackSet(_enemyMove, _rb);
    }
    private void Update()
    {
        _enemyMove.Move();
        _enemyShortAttack3D.ShortAttack();
    }
}
