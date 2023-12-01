using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class StatusEffect : ScriptableObject
{
    private bool statusDone = false;

    public abstract void DoStatusEffect(Enemy enemyiamon); 

    public bool IsStatusDone()
    {
        return statusDone;
    }

    public void FinishStatus()
    {
        statusDone = true;
    }
}
