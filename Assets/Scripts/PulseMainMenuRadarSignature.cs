using UnityEngine;
using Random = UnityEngine.Random;

public class PulseMainMenuRadarSignature : MonoBehaviour
{
    public float initialLifeTime;
    public float fadeoutLifeTime = 2;
    public float maxTimeUntilRespawn;

    public float lifeTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lifeTime = initialLifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        var color = GetComponent<SpriteRenderer>().color;
        color.a = lifeTime < 0 ? 0 : lifeTime / fadeoutLifeTime;
        GetComponent<SpriteRenderer>().color = color;

        if (lifeTime < 0 && -lifeTime > maxTimeUntilRespawn)
        {
            lifeTime = fadeoutLifeTime;
            transform.position = Random.insideUnitCircle * 5;
        }
        
        lifeTime -= Time.deltaTime;
    }
}