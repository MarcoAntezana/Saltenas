using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public GameObject prefabToSpawn; // Prefab que se spawnear�
    public float minSpawnTime = 1f;  // Tiempo m�nimo entre spawns
    public float maxSpawnTime = 5f;  // Tiempo m�ximo entre spawns
    public Transform spawnLocation;  // Lugar donde aparecer�n los objetos (opcional)

    private float nextSpawnTime;     // Tiempo para el pr�ximo spawn

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

        // Instanciar el prefab en la ubicaci�n del spawner o en la posici�n del spawnLocation
        Vector3 spawnPosition = spawnLocation != null ? spawnLocation.position : transform.position;
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }

    void ScheduleNextSpawn()
    {
        // Calcular un tiempo aleatorio para el pr�ximo spawn
        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }
}
