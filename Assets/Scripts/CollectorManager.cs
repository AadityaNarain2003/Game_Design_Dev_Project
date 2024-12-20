using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectorManager : MonoBehaviour
{
    public GameObject beamPrefab; 
    public Transform firePoint; 
    public float beamSpeed = 20f;
    public float fireRate = 0.5f; 
    private float nextFireTime = 0f;

    public TextMeshProUGUI actionText;

    // Add a reference to the AudioSource and the sound effect
    public AudioSource audioSource; // The AudioSource component

    void Update()
    {
        // You can add any additional logic here for things like firing based on time or input
    }

    public void Fire()
    {
        if (beamPrefab == null || firePoint == null) 
        {
            return;
        }

        // Play the firing sound
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }

        // Instantiate the beam
        GameObject beam = Instantiate(beamPrefab, firePoint.position, firePoint.rotation);
        beam.transform.Rotate(90, 0, 0);

        Rigidbody rb = beam.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * beamSpeed;
        }

        Destroy(beam, 5f);
    }
}
