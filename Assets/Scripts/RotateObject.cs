using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 10f; // Degrees per second

    void Update()
    {
        // Calculate the rotation amount for this frame
        float rotationAmount = rotationSpeed * Time.deltaTime; // Multiply by Time.deltaTime for frame-rate independence

        // Apply rotation around the Y axis
        transform.Rotate(0, rotationAmount, 0);
    }
}

