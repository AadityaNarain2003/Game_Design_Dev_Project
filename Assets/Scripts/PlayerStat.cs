using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStat
{
    public float health;
    public bool alive;

    public int points;

    public PlayerStat()
    {
        points= 0;
        health = 100f;
        alive = true; // Player starts alive
    }
    public void DecreaseHealth(){}
}

