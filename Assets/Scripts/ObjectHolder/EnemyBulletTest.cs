using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletTest : RetainedEnemyBulletBehavior
{
    [Range(0, 1), SerializeField] private int _id = 1;

    public override int Id => _id;
}
