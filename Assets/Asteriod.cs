using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;



public class Asteroid : MonoBehaviour
{
    private Vector3 targetPosition;
    private float speed;
    private BoundaryLogger boundaryManager;
    private Vector3 movementDirection;
    private TextMeshProUGUI actionText;
    private AudioSource asteroidAudio;

    // Initialize the asteroid's movement and target position
    public void Initialize(Vector3 playerPosition, float movementSpeed, BoundaryLogger manager, TextMeshProUGUI at)
    {
        targetPosition = playerPosition;
        speed = movementSpeed;
        boundaryManager = manager;
        movementDirection = (targetPosition - transform.position).normalized;
        actionText=at;

        asteroidAudio = GetComponent<AudioSource>();

        if (asteroidAudio != null)
        {
            asteroidAudio.Play();  // Play the audio if it's not already playing
        }


    }

    private void Update()
    {
        // Move the asteroid in the direction that was established at initialization
        transform.position += movementDirection * speed * Time.deltaTime;

        float distanceFromOrigin = Vector3.Distance(Vector3.zero, transform.position);

        // If the asteroid has moved 130 units away from the origin, destroy it
        if (distanceFromOrigin >= 130f)
        {
            Destroy(gameObject);  // Destroy the asteroid
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        actionText.text = "WE COLLIDED";
        if (collision.gameObject.name == "Player")  // Compare with the object's name
        {
            boundaryManager.DecreaseHealth();  // Decrease health
            Destroy(gameObject);  // Destroy the asteroid
        }
    }
}

