using System;
using UnityEngine;

[System.Serializable]
public class PlayerDamage2D : PlayerDamage
{
    private Rigidbody2D _rb2D = default;

    public void Init(Rigidbody2D rb2D, PlayerStateController stateController, PlayerMove playerMove)
    {
        base.Init(stateController, playerMove);
        _rb2D = rb2D;
    }

    public override void OnDamage(
        int value, Vector3 knockBackDir,
        float knockBackPower, int knockBackTime)
    {
        if (!_isGodMode)
        {
            if (_isTest)
            {
                value = _testDamageValue;
                knockBackDir = _testKnockBackDir;
                knockBackPower = _testKnockBackPower;
                knockBackTime = _testKnockBackTime;
            }
            // �m�b�N�o�b�N����
            _rb2D.velocity = Vector3.zero;
            _rb2D.AddForce(knockBackDir.normalized * knockBackPower, ForceMode2D.Impulse);
            // �̗͂����炷
            PlayerStatusManager.Instance.Damage(value);
            _stateController.StateClear();
            // �m�b�N�o�b�N���ARigidBody Velocity �̍X�V���~�߂�
            KnockBackStart(knockBackTime);
        }
    }


}