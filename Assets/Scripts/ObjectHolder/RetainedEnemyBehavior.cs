/// <summary>
/// Enemy‚ÉŒp³‚³‚¹‚éARetainedHolderBehavior‚ªŒp³‚³‚ê‚½ƒNƒ‰ƒX
/// </summary>
public abstract class RetainedEnemyBehavior : RetainedHolderBehavior
{
    public abstract int Id { get; }
            
    public abstract int Health { get; set; }
}
