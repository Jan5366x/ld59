using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float initialTime = 1;

    public float remainingTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        remainingTime = initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        var color = spriteRenderer.color;
        color.a = Mathf.Clamp01(remainingTime/initialTime);
        spriteRenderer.color = color;
        if (remainingTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}