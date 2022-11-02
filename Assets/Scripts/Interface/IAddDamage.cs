public interface IAddDamage
{
    /// <summary>
    /// IAddDamageによって実装される、ダメージを受けた際に呼び出されるメソッド
    /// </summary>
    /// <param name="damage">受けるダメージ</param>
   protected void AddDamage(int damage);
}
