/// <summary>
/// Enemy�Ɍp��������ARetainedHolderBehavior���p�����ꂽ�N���X
/// </summary>
public abstract class RetainedEnemyBehavior : RetainedHolderBehavior
{
    public abstract int Id { get; }
            
    public abstract int Health { get; set; }
}
