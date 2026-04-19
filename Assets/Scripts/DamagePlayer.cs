using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void Start()
    {
        var playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        playerStats.OnDamage();
    }
}