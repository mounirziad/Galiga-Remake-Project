using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY2Controller : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float fireRate = 0.2f;
    private float nextFireTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // Prevents bullets from interacting with ship's collider
        if (bulletPrefab != null && GetComponentInParent<Collider2D>() != null)
        {
            Physics2D.IgnoreCollision(bulletPrefab.GetComponent<Collider2D>(), GetComponentInParent<Collider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = -bulletSpawnPoint.up * bulletSpeed;
    }
}
