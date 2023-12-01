using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Slow", menuName = "StatusEffects/Slow")]
public class SlowDown : StatusEffect
{
    [SerializeField] float modifiedSpeed = 0.75f;

    public override void DoStatusEffect(Enemy enemyiamon)
    {
        //enemyiamon.speed *= modifiedSpeed;
    }
}
