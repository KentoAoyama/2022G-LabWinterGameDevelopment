using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public abstract class PlayerDamage
{
    public bool IsGodMode => _isGodMode;
    public bool IsDamageNow { get => _isDamageNow; set => _isDamageNow = value; }

    [SerializeField]
    protected bool _isTest = false;
    [SerializeField]
    protected int _testDamageValue = 1;
    [SerializeField]
    protected Vector3 _testKnockBackDir = default;
    [SerializeField]
    protected float _testKnockBackPower = 1f;
    [SerializeField]
    protected int _testKnockBackTime = 1;
    [SerializeField]
    protected bool _isGodMode = false;

    private bool _isDamageNow = false;

    protected PlayerStateController _stateController = null;

    protected void Init(PlayerStateController stateController)
    {
        _stateController = stateController;
    }
    public virtual void OnDamage(int value,
        Vector3 knockBackDir, float knockBackPower,
        int knockBackTime)
    {
    }

    // �w��b�m�b�N�o�b�N��Ԃɂ���B�i�w�莞�Ԃ���second�j
    // �i�m�b�N�o�b�N���̓S�b�h���[�h�ɂ���j
    protected async Task KnockBackStart(int sleepTime)
    {
        Debug.Log("�m�b�N�o�b�N�J�n");
        _stateController.CurrentState = PlayerState.DAMAGE;
        _isDamageNow = true;
        _isGodMode = true;
        await Task.Run(() => Thread.Sleep(sleepTime));
        Debug.Log("�m�b�N�o�b�N�I��");
        _isDamageNow = false;
        _isGodMode = false;
    }
}