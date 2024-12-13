using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float tiempoMin = 5f;
    public float tiempoMax = 10f;
    public Transform spawnLocation;

    private float nextSpawnTime;

    void Start()
    {
        ScheduleNextSpawn();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            ScheduleNextSpawn();
        }
    }

    void SpawnObject()
    {
        if (prefabToSpawn == null)
        {
            return;
        }
        Vector3 spawnPosition = spawnLocation != null ? spawnLocation.position : transform.position;
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }

    void ScheduleNextSpawn()
    {
        nextSpawnTime = Time.time + Random.Range(tiempoMin, tiempoMax);
    }

}
