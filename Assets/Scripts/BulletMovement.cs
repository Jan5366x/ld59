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
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var onScan = other.GetComponent<OnScan>();
        if (onScan != null)
        {
            Instantiate(onScan.hitIndicatorPrefab);
            Destroy(onScan.gameObject);
        }
    }
}