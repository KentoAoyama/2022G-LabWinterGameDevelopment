/// <summary>
/// Enemy�Ɍp��������ARetainedHolderBehavior���p�����ꂽ�N���X
/// </summary>
public abstract class RetainedEnemyBehavior : RetainedHolderBehavior
{
    protected abstract int Id { get; }
            
    protected abstract int Health { get; set; }
}
