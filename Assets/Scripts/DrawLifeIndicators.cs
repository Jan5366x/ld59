using System.Collections.Generic;
using UnityEngine;

public class DrawLifeIndicators : MonoBehaviour
{
    public GameObject lifeIndicatorPrefab;
    public Vector3 offset;
    
    PlayerStats playerStats;

    public List<GameObject> lifeIndicators;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        while (playerStats.health > lifeIndicators.Count)
        {
            var instance = Instantiate(lifeIndicatorPrefab, transform.position + offset * lifeIndicators.Count, Quaternion.identity);
            lifeIndicators.Add(instance);
        }
        
        while (playerStats.health < lifeIndicators.Count)
        {
            int index = lifeIndicators.Count - 1;
            Destroy(lifeIndicators[index]);
            lifeIndicators.RemoveAt(index);
        }
    }
}
