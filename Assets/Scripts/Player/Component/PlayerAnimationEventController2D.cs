using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventController2D : MonoBehaviour
{
    private PlayerController2D _playerController = null;
    private void Start()
    {
        _playerController = transform.parent.GetComponent<PlayerController2D>();
    }

    public void OnAttackStart()
    {
        _playerController.AttackProcess();
    }

    public void OnAttackEnd()
    {
        _playerController.EndAttack();
    }
}
