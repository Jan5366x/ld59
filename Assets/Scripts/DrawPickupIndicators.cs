using System.Collections.Generic;
using UnityEngine;

public class DrawPickupIndicators : MonoBehaviour
{
    public UDictionary<PickupType, GameObject> pickupIndicatorPrefabs = new();
    public Vector3 offset;

    PlayerStats playerStats;

    public List<GameObject> pickupIndicators = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.pickupsDirty)
        {
            foreach (var pickupIndicator in pickupIndicators)
            {
                Destroy(pickupIndicator);
            }

            pickupIndicators.Clear();

            for (var i = 0; i < playerStats.activePickups.Count; i++)
            {
                var pickupType = playerStats.activePickups[i];

                var instance = Instantiate(
                    pickupIndicatorPrefabs[pickupType],
                    transform.position + i * offset,
                    Quaternion.identity,
                    transform
                );
                pickupIndicators.Add(instance);
            }

            playerStats.pickupsDirty = false;
        }
    }
}