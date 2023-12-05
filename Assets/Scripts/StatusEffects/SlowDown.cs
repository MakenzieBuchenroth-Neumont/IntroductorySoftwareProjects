using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Slow", menuName = "StatusEffects/Slow")]
public class SlowDown : StatusEffect
{
    [SerializeField] float modifiedSpeed = 0.75f;
    [SerializeField] float duration = 1.0f;

    private float timerTotal = 0;

    public override void DoStatusEffect(Enemy enemyiamon)
    {
        if (!IsStatusDone())
        {
            timerTotal += Time.deltaTime;
            //enemyiamon.speed *= modifiedSpeed;
            if (timerTotal >= duration)
            {
                FinishStatus();
            }
        }
    }
}
