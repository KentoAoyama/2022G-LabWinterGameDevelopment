using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyTest : RetainedHolderBehavior/*RetainedEnemyBehavior*/
{
    [SerializeField] private int hp = 3;
    [Range(1, 2), SerializeField] private int id = 1;

    //private IntReactiveProperty Hp => new(hp);

    //protected override IntReactiveProperty Health => Hp;
    //protected override int Id => id;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.K))
    //    {
    //        Hp.Value--;
    //        Debug.Log(Hp.Value);
    //    }
    //}
}
