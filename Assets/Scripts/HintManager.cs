using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    public List<string> hint;

    public int last_hint=0;

    private int hint_count;

    private int current_hint;
 
    // Start is called before the first frame update
    void Start()
    {
        hint_count=hint.Count;
        current_hint=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool showNextHint()
    {
        return current_hint<last_hint;
    }
    public bool showPreviousHint()
    {
        return current_hint>0;
    }
    public string GetCurrentHint()
    {
        if(current_hint<0 || current_hint>=hint_count)
        {
            return "ERROR";
        }
        return hint[current_hint];
    }
    public string GetHint(int i)
    {
        return hint[i]; 
    }
    public void AddCurrentHint()
    {
        current_hint++;
    }
    public void SubtractCurrentHint()
    {
        current_hint--;
    }
    public void AddLastHint()
    {
        last_hint++;
    }
}
