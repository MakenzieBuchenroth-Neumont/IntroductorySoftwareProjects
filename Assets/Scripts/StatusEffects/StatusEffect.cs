using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class StatusEffect : ScriptableObject
{
    public bool statusDone = false;

    public abstract void DoStatusEffect(Enemy enemyiamon); 
}
