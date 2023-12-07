using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class StatusEffect : ScriptableObject
{
    [SerializeField] private bool statusDone = false;
    public TowerTargeting towerICameFrom;

    public abstract void DoStatusEffect(Enemy enemyiamon); 

    public bool IsStatusDone()
    {
        return statusDone;
    }

    public virtual void FinishStatus()
    {
        statusDone = true;
    }
}
