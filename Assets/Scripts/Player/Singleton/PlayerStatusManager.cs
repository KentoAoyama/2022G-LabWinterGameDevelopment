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
    private readonly IntReactiveProperty _playerLife = new IntReactiveProperty(MAX_PLAYER_LIFE);
    private readonly IntReactiveProperty _bodyTemperature = new IntReactiveProperty(MAX_BODY_TEMPERATURE);
    private readonly IntReactiveProperty _torchLife = new IntReactiveProperty(MAX_TORCH_LIFE);
    #endregion

    #region Constants
    private const int MAX_PLAYER_LIFE = 100;
    private const int MAX_BODY_TEMPERATURE = 100;
    private const int MAX_TORCH_LIFE = 100;
    private const int MAX_TORCH_STATE = 3;
    #endregion

    #region Properties
    /// <summary>
    /// ライフ
    /// </summary>
    public IReadOnlyReactiveProperty<int> PlayerLife => _playerLife;
    /// <summary>
    /// 体温
    /// </summary>
    public IReadOnlyReactiveProperty<int> BodyTemperature => _bodyTemperature;
    /// <summary>
    /// 松明
    /// </summary>
    public IReadOnlyReactiveProperty<int> TorchLife => _torchLife;
    /// <summary>
    /// 松明の状態を表す。
    /// MAX_TORCH_STATEが3であれば、整数値0～2で状態を表現する。
    /// </summary>
    public int TorchState
    { 
        get
        {
            var a = _torchLife.Value/( MAX_TORCH_LIFE / MAX_TORCH_STATE);
            if (a == MAX_TORCH_STATE) a -= 1;
            return a;
        }
    }
    #endregion

    #region Public Methods
    public void Damage(int value)
    {
        _playerLife.Value -= value;
    }
    /// <summary>
    /// 体温減少
    /// </summary>
    public void DecreaseBodyTemperature(int value)
    {
        _bodyTemperature.Value -= value;
    }
    /// <summary>
    /// 松明ライフ減少
    /// </summary>
    public void DecreaseTorchLife(int value)
    {
        _torchLife.Value -= value;
    }
    public void ResetVariable()
    {
        _playerLife.Value = MAX_PLAYER_LIFE;
        _bodyTemperature.Value = MAX_BODY_TEMPERATURE;
        _torchLife.Value = MAX_TORCH_LIFE;
    }
    public void PlayerLifeUp(int value)
    {
        _playerLife.Value += value;
    }
    public void BodyTemperatureUp(int value)
    {
        _bodyTemperature.Value += value;
    }
    public void TorchLifeUp(int value)
    {
        _torchLife.Value += value;
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