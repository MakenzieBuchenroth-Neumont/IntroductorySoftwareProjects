using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "new DOT", menuName = "StatusEffects/DamageOverTime")]
public class DamageOverTime : StatusEffect
{
    [SerializeField] float duration = 1.0f;
    [SerializeField] int tickAmount = 1;
    [SerializeField] int damage = 1;

    [SerializeField] private float timerTotal = 0;
    [SerializeField] private float timerTick = 0;

    public override void DoStatusEffect(Enemy enemyiamon)
    {
        if (!IsStatusDone())
        {
            timerTotal += Time.deltaTime;
            timerTick += Time.deltaTime;

            if (timerTick >= (duration / tickAmount))
            {
                //enemyiamon.TakeDamage(damage);
                timerTick = 0;
            }

            if (timerTotal >= duration)
            {
                //enemyiamon.TakeDamage(damage);
                FinishStatus();
            }
        }
    }
}
