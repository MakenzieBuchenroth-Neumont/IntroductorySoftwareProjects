using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "new DOT", menuName = "StatusEffects/DamageOverTime")]
public class DamageOverTime : StatusEffect
{
    [SerializeField] float timeBetweenTicks = 0.25f;
    [SerializeField] int tickAmount;
    [SerializeField] int damage;

    public override void DoStatusEffect()
    {
        
    }
}
