using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawPickupIndicators : MonoBehaviour
{
    public UDictionary<PickupType, GameObject> pickupIndicatorPrefabs = new();
    public Vector3 offset;
    public Vector3 offsetStacked;

    PlayerStats playerStats;

    public UDictionary<PickupType, List<GameObject>> pickupIndicators = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        int pickupTypeIndex = 0;
        var pickupTypes = Enum.GetValues(typeof(PickupType)).Cast<PickupType>();
        foreach (var pickupType in pickupTypes)
        {
            if (!pickupIndicators.ContainsKey(pickupType))
            {
                pickupIndicators.Add(pickupType, new List<GameObject>());
            }

            if (playerStats.collectedPickups.ContainsKey(pickupType))
            {
                while (playerStats.collectedPickups[pickupType] > pickupIndicators[pickupType].Count)
                {
                    var typeOffset = offset * pickupTypeIndex;/*  new Vector3(
                        pickupTypeIndex % 2 == 0 ? 0 : offset.x,
                        // ReSharper disable once PossibleLossOfFraction
                        offset.y * (pickupTypeIndex / 2),
                        0
                    );*/
                    var stackedOffset = offsetStacked * pickupIndicators[pickupType].Count;

                    var instance = Instantiate(
                        pickupIndicatorPrefabs[pickupType],
                        transform.position + typeOffset + stackedOffset,
                        Quaternion.identity,
                        transform
                    );
                    pickupIndicators[pickupType].Add(instance);
                }
            }

            pickupTypeIndex++;
        }
    }
}