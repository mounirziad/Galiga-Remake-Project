using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    void Start()
    {
        if (bulletPrefab != null && GetComponentInParent<Collider2D>() != null)
        {
            Physics2D.IgnoreCollision(bulletPrefab.GetComponent<Collider2D>(), GetComponentInParent<Collider2D>());
        }
    }

    void Update ()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
            Debug.Log("Shooting");
        }
    }
}
