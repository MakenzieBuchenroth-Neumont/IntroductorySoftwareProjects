using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

[CreateAssetMenu(fileName = "new Slow", menuName = "StatusEffects/Slow")]
public class SlowDown : StatusEffect
{
    [SerializeField] float modifySpeed = 0.75f;
    [SerializeField] float duration = 1.0f;

    [SerializeField] private float timerTotal = 0;
    private Enemy enemyion;
    bool used = false;

    public override void DoStatusEffect(Enemy enemyiamon)
    {
        if (!IsStatusDone())
        {
            timerTotal += Time.deltaTime;
            if (!used)
            {
                enemyiamon.speed *= modifySpeed;
                enemyion = enemyiamon;
                used = true;
            }
            if (timerTotal >= duration)
            {
                FinishStatus();
            }
        }
    }

    public override void FinishStatus()
    {
        base.FinishStatus();
        enemyion.speed /= modifySpeed;
    }
}
