//using UniRx;

//public abstract class RetainedEnemyBehavior : RetainedHolderBehavior
//{
//    protected abstract IntReactiveProperty Health { get;}
//    protected abstract int Id { get;}

//    private DimentionManager.EnemyStatus enemyStatus = new();

//    protected override void Awake()
//    {
//        base.Awake();
//        Health.Subscribe(h =>
//        {
//            enemyStatus.Health = h;
//        }).AddTo(this);

//        enemyStatus.Id = Id;
//    }
//}
