using UnityEngine;

public class DrawGunIndicator : MonoBehaviour
{
    public GameObject remainingIndicator;
    public GunControl gunControl;

    PlayerStats playerStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        var gunFiringDelay = playerStats.GetGunFiringDelay();
        var remainingFireDelay = Mathf.Clamp(gunControl.remainingFireDelay, 0, gunFiringDelay);

        remainingIndicator.transform.localScale = new Vector3(remainingFireDelay / gunFiringDelay, 1, 1);
    }
}