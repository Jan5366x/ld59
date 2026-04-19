using UnityEngine;

public class Radar : MonoBehaviour
{
    PlayerStats playerStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * playerStats.radarSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var onScanPrefab = other.GetComponent<OnScan>();
        if (onScanPrefab != null)
        {
            onScanPrefab.wasScanned = true;
            Instantiate(onScanPrefab.scanIndicatorPrefab, other.transform.position, Quaternion.identity);
        }
    }
}