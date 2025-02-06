using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Apple : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float fireRate = 0.2f;
    private int enemiesAlive;
    GameObject gameManagerObject;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        // Prevents bullets from interacting with ship's collider
        if (bulletPrefab != null && GetComponentInParent<Collider2D>() != null)
        {
            Physics2D.IgnoreCollision(bulletPrefab.GetComponent<Collider2D>(), GetComponentInParent<Collider2D>());
        }

        InvokeRepeating(nameof(Shoot), this.fireRate, this.fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        enemiesAlive = gameManager.enemiesAlive;
    }

    void Shoot()
    {
        // Apple critters shoot more as the player kills more enemies
        if (Random.value < (1.0f / (float)enemiesAlive))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = -bulletSpawnPoint.up * bulletSpeed;
        }
    }
}
