using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoundaryLogger : MonoBehaviour
{
    public PlayerStat stats;
    private int warning;
    int distance=100;
    private float distanceFromOrigin;

    public TextMeshProUGUI actionText;
    // Start is called before the first frame update
    void Start()
    {
        stats = new PlayerStat();
        warning=0;
        distanceFromOrigin=0;
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromOrigin = Vector3.Distance(transform.position, Vector3.zero);
        if(distanceFromOrigin<distance)
        {
            warning = 0;
            //actionText.text = "You are inside";
        }
        else if( distanceFromOrigin<distance+10)
        {
            warning = 1;
            //actionText.text = "You are at the border";
        }
        else
        {
            warning = 2;
            stats.alive=false;
            //actionText.text = "Oh god, you got lost in deep space";
        }
        //  actionText.text = $"{stats.points}";
    }

    public float getHealth()
    {
        return stats.health;
    }
    public int getPoint()
    {
        return stats.points;
    }
    public float getDistance()
    {
        return distanceFromOrigin;
    }
    public int getWarning()
    {
        return warning;
    }
    public void DecreaseHealth()
    {
        stats.health-=20;
    }
}
