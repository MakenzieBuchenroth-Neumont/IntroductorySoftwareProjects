using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Wave", menuName = "Wave")]
public class Wave : ScriptableObject
{
    [SerializeField] private List<Batch> batches;

    public List<Batch> GetBatches() { return batches; }
}
