using System;
using UnityEngine;

[Serializable]
public class DropPickupData
{
    [Min(0)] public int weight;

    public GameObject prefab;
}