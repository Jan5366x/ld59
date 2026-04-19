using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /**
     * Weighted map of enemies to spawn
     */
    public SpawnData[] enemyPrefabs;

    public float remainingCooldown = 0;
    public float minSpawnRadius = 5;
    public float maxSpawnRadius = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        remainingCooldown -= Time.deltaTime;
        if (remainingCooldown < 0)
        {
            var spawnData = SelectSpawn();
            remainingCooldown = spawnData.cooldown;
            foreach (var spawnDataPrefab in spawnData.prefabs)
            {
                var mewPosition = Random.onUnitCircle * Random.Range(minSpawnRadius, maxSpawnRadius);
                Instantiate(spawnDataPrefab, new Vector3(mewPosition.x, mewPosition.y), Quaternion.identity);
            }
        }
    }

    private SpawnData SelectSpawn()
    {
        int totalWeight = 0;
        for (var i = 0; i < enemyPrefabs.Length; i++)
        {
            totalWeight += enemyPrefabs[i].weight;
        }

        var targetWeight = Random.Range(0, totalWeight);
        totalWeight = 0;
        for (var i = 0; i < enemyPrefabs.Length; i++)
        {
            totalWeight += enemyPrefabs[i].weight;
            if (totalWeight > targetWeight)
            {
                return enemyPrefabs[i];
            }
        }

        throw new System.NotImplementedException();
    }
}