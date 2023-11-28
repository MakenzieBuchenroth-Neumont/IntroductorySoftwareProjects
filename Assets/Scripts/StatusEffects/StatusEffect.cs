using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class StatusEffect : ScriptableObject
{
    public bool statusDone;

    public void Awake()
    {
        statusDone = false;
    }

    public abstract void DoStatusEffect(); 
}
