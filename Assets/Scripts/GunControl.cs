using UnityEngine;

public class GunControl : MonoBehaviour
{
    public float angle = 0;
    public float moveSpeed = 100f;

    public GameObject bulletPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle += Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        
        
    }
}
