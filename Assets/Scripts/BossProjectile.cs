using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle player getting hit
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject); // Destroy when hitting the screen edge
        }
    }
}
