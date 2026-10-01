using UnityEngine;

public class CannonSpawner : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject cannonBall;

    [Header("Spawn Position")]
    [SerializeField] private Transform spawnPos;

    [Header("Spawn Time")]
    [SerializeField] private float spawnInterval = 1.0f;    //Spawn interval for cannon

    private float currentSpawnTimer;

    void Start()
    {
        if (spawnPos == null)
            spawnPos = transform;
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
        Instantiate(cannonBall, spawnPos.position, Quaternion.identity);
    }
}
