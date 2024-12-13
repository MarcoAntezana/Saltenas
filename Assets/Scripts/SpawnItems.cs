using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public GameObject prefabToSpawn; // Prefab que se spawneará
    public float minSpawnTime = 1f;  // Tiempo mínimo entre spawns
    public float maxSpawnTime = 5f;  // Tiempo máximo entre spawns
    public Transform spawnLocation;  // Lugar donde aparecerán los objetos (opcional)

    private float nextSpawnTime;     // Tiempo para el próximo spawn

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
            Debug.LogWarning("No hay prefab asignado para spawnear.");
            return;
        }

        // Instanciar el prefab en la ubicación del spawner o en la posición del spawnLocation
        Vector3 spawnPosition = spawnLocation != null ? spawnLocation.position : transform.position;
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }

    void ScheduleNextSpawn()
    {
        // Calcular un tiempo aleatorio para el próximo spawn
        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }
}
