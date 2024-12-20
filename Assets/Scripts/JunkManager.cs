using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkManager : MonoBehaviour
{
    public GameObject junks;

    public int count;
    public int radius;

    // Start is called before the first frame update
    void Start()
    {
        count = 3;
        radius = 30;
        SpawnJunk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void SpawnJunk()
    {
        for (int i = 0; i < count; i++)
        {
            // Generate a random position within a sphere of the specified radius
            Vector3 randomPosition = Random.insideUnitSphere * radius;

            // Instantiate the junk prefab at the random position
            Instantiate(junks, randomPosition, Quaternion.identity);
        }
    }
}
