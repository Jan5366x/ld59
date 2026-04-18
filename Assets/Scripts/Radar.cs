using UnityEngine;

public class Radar : MonoBehaviour
{
    public float speed = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var onScanPrefab = other.GetComponent<OnScan>();
        if (onScanPrefab != null)
        {
            Instantiate(onScanPrefab.scanIndicatorPrefab, other.transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.name);
    }
}
