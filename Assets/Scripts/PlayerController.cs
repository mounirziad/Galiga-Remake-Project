using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f;
    public float fireRate = 0.2f;
    private float nextFireTime = 0f;
    public bool isFrozen = false; // Player starts frozen

    void Update()
    {
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, Camera.main.nearClipPlane));

        if (isFrozen) return; // Prevent movement when frozen

        Vector3 newPosition = transform.position;

        // Move Left
        if (Input.GetKey(KeyCode.A))
        {
            newPosition += Vector3.left * moveSpeed * Time.deltaTime;
        }

        // Move Right
        if (Input.GetKey(KeyCode.D))
        {
            newPosition += Vector3.right * moveSpeed * Time.deltaTime;
        }

        // Clamp position within screen bounds
        newPosition.x = Mathf.Clamp(newPosition.x, leftEdge.x + 1.0f, rightEdge.x - 1.0f);

        // Apply the clamped position
        transform.position = newPosition;

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
    }

    public void Unfreeze() // Call this from the game manager when ready
    {
        isFrozen = false;
    }
}