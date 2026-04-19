using UnityEngine;
using Random = UnityEngine.Random;

public class BulletMovement : MonoBehaviour
{
    public float speed;
    
    PlayerStats playerStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var onScan = other.GetComponent<OnScan>();
        if (onScan != null)
        {
            if (onScan.wasScanned)
            {
                Instantiate(onScan.hitIndicatorPrefabs, other.transform.position, Quaternion.identity);
                InstantiateDrop(onScan);

                playerStats.Score(onScan.scorePoints);
                Destroy(onScan.gameObject);
                return;
            }
        }

        var pickup = other.GetComponent<Pickup>();
        if (pickup != null)
        {
            if (pickup.pickupDelay < 0)
            {
                Instantiate(pickup.hitIndicatorPrefab, other.transform.position, Quaternion.identity);
                var player = GameObject.FindGameObjectWithTag("Player");
                var playerStats = player.GetComponent<PlayerStats>();
                playerStats.CollectPickup(pickup);
                Destroy(pickup.gameObject);
                return;
            }
        }
    }

    private void InstantiateDrop(OnScan onScan)
    {
        int totalWeight = 0;
        foreach (var onScanHitIndicatorPrefab in onScan.hitIndicatorDrops)
        {
            totalWeight += onScanHitIndicatorPrefab.weight;
        }

        int weight = Random.Range(0, totalWeight);
        totalWeight = 0;
        foreach (var drop in onScan.hitIndicatorDrops)
        {
            totalWeight += drop.weight;
            if (totalWeight > weight)
            {
                if (drop.prefab != null)
                {
                    Instantiate(drop.prefab, onScan.transform.position, Quaternion.identity);
                }

                break;
            }
        }
    }
}