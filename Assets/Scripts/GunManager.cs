using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public   GameObject bulletPrefab; 
    public   Transform firePoint; 
    public   float bulletSpeed = 20f;
    public   float fireRate = 0.5f; 
    private   float nextFireTime = 0f;

    public AudioSource audioSource;
    void Update()
    {

    }

    public   void Fire()
    {

        if (bulletPrefab == null || firePoint == null) return;

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }

        Destroy(bullet, 5f);
    }
}
