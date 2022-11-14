/// <summary>
/// EnemyBulletに継承させる、RetainedHolderBehaviorが継承されたクラス
/// </summary>
public abstract class RetainedEnemyBulletBehavior : RetainedHolderBehavior
{
    protected abstract int Id { get; }
}
