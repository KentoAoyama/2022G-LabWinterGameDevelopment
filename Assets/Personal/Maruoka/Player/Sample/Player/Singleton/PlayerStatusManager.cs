using UnityEngine;
using UniRx;

/// <summary>
/// �v���C���[�̃X�e�[�^�X���Ǘ�����V���O���g��
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
    /// ���C�t
    /// </summary>
    public IReadOnlyReactiveProperty<int> Life => _life;
    /// <summary>
    /// �̉�
    /// </summary>
    public IReadOnlyReactiveProperty<int> BodyTemperature => _bodyTemperature;
    /// <summary>
    /// ����
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
    // ���̃N���X�̃I�u�W�F�N�g���j�������̂̓A�v���P�[�V�����I�����̂��ߕK�v�Ȃ��H
    //private void Dispose()
    //{
    //    _life.Dispose();
    //    _bodyTemperature.Dispose();
    //    _torch.Dispose();
    //}
    #endregion
}