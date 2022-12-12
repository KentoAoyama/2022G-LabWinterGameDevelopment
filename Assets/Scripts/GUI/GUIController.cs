using UniRx;
using UnityEngine;

public class GUIController : MonoBehaviour
{
    //Player�p�����[�^�̑���
    PlayerStatusManager playerStatusManager;
    //HP�Q�[�W
    [SerializeField] PlayerGauge hpBar;
    [SerializeField] PlayerGauge temperatureBar;

    int playerLifeMax;
    int BodyTemperatureMax;

    void Start()
    {
        playerStatusManager = PlayerStatusManager.Instance;
        playerLifeMax = playerStatusManager.PlayerLife.Value;
        BodyTemperatureMax = playerStatusManager.BodyTemperature.Value;

        playerStatusManager.PlayerLife
            .Subscribe(x =>
            {
                hpBar.SetValues(1-(float)x / playerLifeMax);
            }).AddTo(this);

        playerStatusManager.BodyTemperature
            .Subscribe(x =>
            {
                temperatureBar.SetValues(1 - (float)x / BodyTemperatureMax);
            }).AddTo(this);
    }
}
