using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventController3D : MonoBehaviour
{
    private PlayerController3D _playerController = null;

    void Start()
    {
        _playerController = transform.parent.GetComponent<PlayerController3D>();
    }

    private void OnAttackEnd()
    {
        _playerController.EndAttack();
    }
}
