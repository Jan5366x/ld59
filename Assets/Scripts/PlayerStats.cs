using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 8;
    public int maxGunSpeed = 200;
    public int maxRadarSpeed = 1000;

    public int health = 4;
    public int gunSpeed;

    public int radarSpeed;

    public void CollectPickup(Pickup pickup)
    {
        health = Math.Min(maxHealth, health + pickup.health);
        gunSpeed = Math.Min(maxGunSpeed, gunSpeed + pickup.gunSpeed);
        radarSpeed = Math.Min(maxRadarSpeed, radarSpeed + pickup.radarSpeed);
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
        Debug.Log("Game Over");
    }
}