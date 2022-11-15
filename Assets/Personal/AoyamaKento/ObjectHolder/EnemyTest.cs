using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyTest : RetainedEnemyBehavior
{
    [SerializeField] private int _hp = 3;
    [Range(0, 1), SerializeField] private int _id = 1;

    public override int Id => _id;
    public override int Health { get => _hp; set => _hp = value; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _hp--;
            Debug.Log(_hp);
        }
    }
}
