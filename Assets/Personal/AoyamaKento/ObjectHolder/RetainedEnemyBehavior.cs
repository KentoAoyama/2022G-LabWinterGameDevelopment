//using UniRx;

public abstract class RetainedEnemyBehavior : RetainedHolderBehavior
{
    protected abstract int Id { get; }
            
    protected abstract int Health { get; }
}
