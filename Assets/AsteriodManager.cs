using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AsteroidManager : MonoBehaviour
{
    public GameObject player;  // The player GameObject
    public GameObject asteroidPrefab;  // The asteroid prefab
    public BoundaryLogger boundaryManager;  // Reference to the BoundaryManager (handles health)
    public TextMeshProUGUI actionText;
    
    public float spawnDistance = 100f;  // Distance at which asteroids spawn
    public float asteroidSpeed = 5f;  // Speed of asteroids
    public float spawnInterval = 30f;  // Interval between asteroid spawns

    private void Start()
    {
        // Start the periodic spawning of asteroids
        InvokeRepeating(nameof(SpawnAsteroid), 0f, spawnInterval);
    }

    private void SpawnAsteroid()
    {
        // Calculate a random position around the player within a spawn distance
        Vector3 spawnPosition = player.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * spawnDistance;
        
        // Instantiate the asteroid at the calculated spawn position
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        
        // Get the asteroid script component and initialize it
        Asteroid asteroidScript = asteroid.GetComponent<Asteroid>();
        asteroidScript.Initialize(player.transform.position, asteroidSpeed, boundaryManager,actionText);
    }
}
