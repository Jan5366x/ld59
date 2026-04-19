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
        transform.
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var onScan = other.GetComponent<OnScan>();
        if (onScan != null)
        {
            Instantiate(onScan.hitIndicatorPrefab, transform.position, Quaternion.identity);
            Destroy(onScan.gameObject);
        }
    }
}