using UnityEngine;
using UniRx;

/// <summary>
/// プレイヤーのステータスを管理するシングルトン
/// </summary>
public class PlayerStatusManager
{
    #region Singleton
    private static PlayerStatusManager _instance = new PlayerStatusManager();
    public static PlayerStatusManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"Error! Please correct!");
            }
            return _instance;
        }
    }
    private PlayerStatusManager() { }
    #endregion

    #region Member Variables
    private readonly IntReactiveProperty _life = new IntReactiveProperty(10);
    private readonly IntReactiveProperty _bodyTemperature = new IntReactiveProperty();
    private readonly IntReactiveProperty _torch = new IntReactiveProperty();
    #endregion

    #region Properties
    /// <summary>
    /// ライフ
    /// </summary>
    public IReadOnlyReactiveProperty<int> Life => _life;
    /// <summary>
    /// 体温
    /// </summary>
    public IReadOnlyReactiveProperty<int> BodyTemperature => _bodyTemperature;
    /// <summary>
    /// 松明
    /// </summary>
    public IReadOnlyReactiveProperty<int> Torch => _torch;
    #endregion

    #region Public Methods
    public void Damage(int value)
    {
        _life.Value -= value;
    }
    #endregion

    #region Private Methods
    // このクラスのオブジェクトが破棄されるのはアプリケーション終了時のため必要ない？
    //private void Dispose()
    //{
    //    _life.Dispose();
    //    _bodyTemperature.Dispose();
    //    _torch.Dispose();
    //}
    #endregion
}