using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk : MonoBehaviour
{
    private PlayerStat playerStat;

    void Start () 
    {
        BoundaryLogger boundaryLogger = FindObjectOfType<BoundaryLogger>();
        if (boundaryLogger != null)
        {
            playerStat = boundaryLogger.stats;
        }
        else
        {
            Debug.LogError("BoundaryLogger not found in the scene!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Beam"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject); 
            addPoints(100);
        }
    }
    public void addPoints(int points)
    {
        if (playerStat != null)
        {
            playerStat.points += points;
        }
    }
}

