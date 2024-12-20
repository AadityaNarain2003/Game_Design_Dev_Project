using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1.0f;

    void Update()
    {
        float newY = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
    }
}

