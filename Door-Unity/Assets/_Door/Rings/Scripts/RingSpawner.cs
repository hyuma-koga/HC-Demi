using UnityEngine;

public class RingSpawner : MonoBehaviour
{
    public GameObject prefab_Ring;
    public Transform player;
    public float spawnOffsetX = 20f;
    public float minY = -2f;
    public float maxY = 2f;
    public float minSpawnInterval = 5f;
    public float maxSpawnInterval = 7f;

    private float nextSpawnX;

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
        Instantiate(prefab_Ring, spawnPosition, Quaternion.identity);
    }
}
