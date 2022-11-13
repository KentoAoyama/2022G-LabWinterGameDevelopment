using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyTest : RetainedEnemyBehavior
{
    [SerializeField] private int _hp = 3;
    [Range(1, 2), SerializeField] private int _id = 1;

    protected override int Id => _id;
    protected override int Health => _hp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _hp--;
            Debug.Log(_hp);
        }
    }
}
