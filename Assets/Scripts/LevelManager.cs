using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelManager : MonoBehaviour
{
    public List<string> constellations;

    public int max_attempts;
    private int max_hints_per_constellation;

    private int current_task;
    private int max_task;
    
    public TextMeshProUGUI actionText;
    // Start is called before the first frame update
    void Start()
    {
        //max_attempts=4;
        max_hints_per_constellation=2;
        current_task=0;
        max_task=constellations.Count;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public string getCurrentConstellation()
    {
        return constellations[current_task];
    }
    public void goToNextTask()
    {
        current_task++;
    }
    public int getCurrentTask()
    {
        return current_task;
    }
    public bool winAndGameOver()
    {
        return current_task >= max_task;
    }
    public bool loseAndGameOver()
    {
        return max_attempts==0;
    }
    public bool isHintAvailable()
    {
        return max_hints_per_constellation>0;
    }
    public void UseHint()
    {   
        max_hints_per_constellation--;
    }
    public void ResetHint()
    {
        max_hints_per_constellation=2;
    }
    public void Attempt()
    {
        max_attempts--;
    }
    public int getAttempts()
    {
        return max_attempts;
    }
    public int getRemainingContellationsCount()
    {
        return max_task- current_task;
    }
}
