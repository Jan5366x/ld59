using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            foreach (var onScanHitIndicatorPrefab in onScan.hitIndicatorPrefabs)
            {
                Instantiate(onScanHitIndicatorPrefab, transform.position, Quaternion.identity);
            }

            Destroy(onScan.gameObject);
            return;
        }

        var pickup = other.GetComponent<Pickup>();
        if (pickup != null)
        {
            if (pickup.pickupDelay < 0)
            {
                Instantiate(pickup.hitIndicatorPrefab, transform.position, Quaternion.identity);
                var player = GameObject.FindGameObjectWithTag("Player");
                var playerStats = player.GetComponent<PlayerStats>();
                playerStats.health += pickup.health;
                playerStats.gunSpeed += pickup.gunSpeed;
                playerStats.radarSpeed += pickup.radarSpeed;

                Destroy(pickup.gameObject);
                return;
            }
        }
    }
}