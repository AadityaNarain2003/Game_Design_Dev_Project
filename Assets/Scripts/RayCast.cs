using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RayCast : MonoBehaviour
{
    public Transform handTransform; // Assign this in the inspector
    public float laserLength = 4000f;
    private LineRenderer lineRenderer;
    private bool isLaserActive = false;

    private string constellationName;

    public TextMeshProUGUI actionText;

    // Layer mask for the constellation layer
    public LayerMask constellationLayer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false; 
        constellationName = "";
    }

    void Update()
    {
        if (isLaserActive)
        {
            // Set the laser's start position to the hand's position
            Vector3 laserStart = handTransform.position;
            // Calculate the end position based on the hand's forward direction
            Vector3 laserEnd = laserStart + handTransform.forward * laserLength;

            // Update the line renderer positions
            lineRenderer.SetPosition(0, laserStart);
            lineRenderer.SetPosition(1, laserEnd);

            // Check for intersection
            CheckForIntersection(laserStart, laserEnd);
        }
    }

    private void CheckForIntersection(Vector3 start, Vector3 end)
    {
        RaycastHit hitInfo;
        // Perform a raycast
        if (Physics.Linecast(start, end, out hitInfo, constellationLayer))
        {
            Debug.Log("Intersection detected with: " + hitInfo.collider.gameObject.name);
            actionText.text = $"Intersected: {hitInfo.collider.gameObject.name}";
            SetConstellationName(hitInfo.collider.gameObject.name);
            // You can add additional handling for intersection here (e.g., highlight the object)
        }
        else
        {
            SetConstellationName("NONE");
        }
    }

    public void ToggleLaser(bool isActive)
    {
        isLaserActive = isActive;
        lineRenderer.enabled = isActive; // Show or hide the laser
    }

    public string GetConstellationName()
    {
        return constellationName;
    }

    public void SetConstellationName(string name)
    {
        constellationName = name;
    }
}
