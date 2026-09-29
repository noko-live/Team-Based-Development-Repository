using UnityEngine;

public class CannonSpawner : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject cannonBall;

    [Header("Spawn Position")]
    [SerializeField] private Vector3 spawnPos;

    [Header("Spawn Time")]
    [SerializeField] private float spawnInterval = 1.0f;    //Spawn interval for cannon

    private float currentSpawnTimer;

    void Start()
    {
        if (spawnPos == Vector3.zero)
            spawnPos = transform.position;
    }

    void Update()
    {
        currentSpawnTimer += Time.deltaTime;

        if (currentSpawnTimer >= spawnInterval)
        {
            SpawnObject();
            currentSpawnTimer = 0f;
        }
    }

    void SpawnObject()
    {
        GameObject spawned = Instantiate(cannonBall, spawnPos, Quaternion.identity);
        // Optional: add to this spawner as a child
        spawned.transform.SetParent(transform);
    }
}
