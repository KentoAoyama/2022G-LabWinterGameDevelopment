/// <summary>
/// Enemy‚ÉŒp³‚³‚¹‚éARetainedHolderBehavior‚ªŒp³‚³‚ê‚½ƒNƒ‰ƒX
/// </summary>
public abstract class RetainedEnemyBehavior : RetainedHolderBehavior
{
    protected abstract int Id { get; }
            
    protected abstract int Health { get; set; }
}
