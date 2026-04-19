using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnData
{
    [Min(0)]
    public int weight;

    public List<GameObject> prefabs;
    
    [Min(0)]
    public float cooldown;
}
