using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5;
    public float hInput;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float fireRate = 0.2f;
    private float nextFireTime = 0f;
<<<<<<< Updated upstream
=======
    public bool isFrozen = false; // Player starts frozen
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        if (bulletPrefab != null && GetComponentInParent<Collider2D>() != null)
        {
            Physics2D.IgnoreCollision(bulletPrefab.GetComponent<Collider2D>(), GetComponentInParent<Collider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector2.right * hInput * moveSpeed * Time.deltaTime);

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
            Debug.Log("Shooting");
    }
}
