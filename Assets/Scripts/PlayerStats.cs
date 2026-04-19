using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 8;
    public int maxGunSpeed = 200;
    public int maxRadarSpeed = 1000;
    public float minFireDelay = 0.3f;
    public float maxFireDelay = 2f;

    public int health = 4;
    public int gunSpeed;
    public float fireDelay = 1f;

    public int radarSpeed;
    public UDictionary<PickupType, int> collectedPickups = new();

    public void CollectPickup(Pickup pickup)
    {
        health = Math.Min(maxHealth, health + pickup.health);
        gunSpeed = Math.Min(maxGunSpeed, gunSpeed + pickup.gunSpeed);
        radarSpeed = Math.Min(maxRadarSpeed, radarSpeed + pickup.radarSpeed);
        fireDelay = Math.Max(minFireDelay, fireDelay - pickup.fireDelay);
        collectedPickups[pickup.pickupType] = (collectedPickups.ContainsKey(pickup.pickupType) ? collectedPickups[pickup.pickupType] : 0) + 1;
    }

    public void OnDamage()
    {
        health = Math.Max(0, health - 1);
        fireDelay = Math.Min(maxFireDelay, fireDelay + 0.1f);
        if (health <= 0)
        {
            ShowGameOverScreen();
        }
    }

    private void ShowGameOverScreen()
    {
        Time.timeScale = 0;
        GetComponentInChildren<GameOverButtons>().OpenGameOverPanel();
    }
}