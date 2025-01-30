using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float hInput;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f;
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
        // Ship moves left when holding down A
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * this.moveSpeed * Time.deltaTime;
        }
        // Ship moves right when holding down D
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * this.moveSpeed * Time.deltaTime;
        }

        // Shoots when space is held down
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
    }
}
