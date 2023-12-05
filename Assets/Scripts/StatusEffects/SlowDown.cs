using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Slow", menuName = "StatusEffects/Slow")]
public class SlowDown : StatusEffect
{
    [SerializeField] float modifySpeed = 0.75f;
    [SerializeField] float duration = 1.0f;

    [SerializeField] private float timerTotal = 0;

    public override void DoStatusEffect(Enemy enemyiamon)
    {
        if (!IsStatusDone())
        {
            timerTotal += Time.deltaTime;
            enemyiamon.speed *= modifySpeed;
            if (timerTotal >= duration)
            {
                FinishStatus();
            }
        }
    }
}
