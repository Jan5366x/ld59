using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject hitIndicatorPrefab;
    public int health;
    public int gunSpeed;
    public int radarSpeed;
    public float fireDelay;
    public PickupType pickupType;
    
    public float initialPickupDelay;
    public float pickupDelay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickupDelay = initialPickupDelay;
    }

    // Update is called once per frame
    void Update()
    {
        pickupDelay -= Time.deltaTime;
    }
}
