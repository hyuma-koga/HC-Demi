using UnityEngine;
using System.Collections.Generic;

public class RingSpawner : MonoBehaviour
{
    public GameObject prefab_Ring;
    public Transform player;
    public float spawnOffsetX = 20f;
    public float minY = -2f;
    public float maxY = 2f;
    public float minSpawnInterval = 4f;
    public float maxSpawnInterval = 6f;

    private float nextSpawnX;
    private List<GameObject> spawnedRings = new List<GameObject>();

    private void Start()
    {
        nextSpawnX = player.position.x + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        if(player.position.x + spawnOffsetX >= nextSpawnX)
        {
            SpawnRing();
            nextSpawnX += Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    private void SpawnRing()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(nextSpawnX, randomY, 0f);
        GameObject ring = Instantiate(prefab_Ring, spawnPosition, Quaternion.identity);
        RingCheck ringCheck = ring.GetComponent<RingCheck>();
        if (ringCheck != null)
        {
            ringCheck.player = player;
        }
        
        spawnedRings.Add(ring);
    }

    public void ResetSpawner()
    {
        foreach (GameObject ring in spawnedRings)
        {
            if (ring != null)
            {
                Destroy(ring);
            }
        }

        spawnedRings.Clear();
        nextSpawnX = player.position.x + Random.Range(minSpawnInterval, maxSpawnInterval);
    }
}
