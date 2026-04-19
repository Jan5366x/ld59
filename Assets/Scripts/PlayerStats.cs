using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int baseHealth = 4;
    public int baseGunRotationSpeed = 100;
    public float baseGunFiringDelay = 1f;
    public int baseRadarRotationSpeed = 200;

    public int addGunRotationSpeed = 70;
    public float addGunFiringDelay = 0.3f;
    public int addRadarRotationSpeed = 100;

    public int maxHealth = 8;
    public int maxGunSpeed = 200;
    public int maxRadarSpeed = 500;
    public float minFireDelay = 0.2f;

    public int health = 4;

    public List<PickupType> activePickups = new();
    public bool pickupsDirty;

    public int pointCount;
    public bool pointsDirty;

    private void Start()
    {
        activePickups.Add(PickupType.HEALTH);
        activePickups.Add(PickupType.HEALTH);
        activePickups.Add(PickupType.HEALTH);
        activePickups.Add(PickupType.HEALTH);
        pickupsDirty = true;
        health = baseHealth;
    }

    public void CollectPickup(Pickup pickup)
    {
        activePickups.Add(pickup.pickupType);
        while (activePickups.Count > 4)
        {
            activePickups.RemoveAt(0);
        }

        pickupsDirty = true;

        if (pickup.pickupType == PickupType.HEALTH)
        {
            health = Math.Min(maxHealth, health + pickup.health);
        }
    }

    public int getHealth()
    {
        return health;
    }

    public int GetGunRotationSpeed()
    {
        var count = activePickups.Count(type => type == PickupType.GUN_ROTATION_SPEED);
        return Math.Min(maxGunSpeed, baseGunRotationSpeed + count * addGunRotationSpeed);
    }

    public float GetGunFiringDelay()
    {
        var count = activePickups.Count(type => type == PickupType.GUN_FIRING_SPEED);
        return Math.Max(minFireDelay, baseGunFiringDelay - count * addGunFiringDelay);
    }

    public int GetRadarRotationSpeed()
    {
        var count = activePickups.Count(type => type == PickupType.RADAR_SPEED);
        return Math.Min(maxRadarSpeed, baseRadarRotationSpeed + count * addRadarRotationSpeed);
    }

    public void OnDamage()
    {
        health = Math.Max(0, health - 1);
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