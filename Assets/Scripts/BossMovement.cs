using System.Collections;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 1.5f;
    private bool canShoot = false;

    public Sprite normalSprite;  // Default boss sprite
    public Sprite fireSprite;    // Firing sprite
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the sprite renderer
        StartCoroutine(BossIntroSequence());
    }

    void Update()
    {
        if (canShoot)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            moveSpeed *= -1;
        }
    }

    IEnumerator BossIntroSequence()
    {
        while (transform.position.y > 1f)
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        while (transform.position.y < 2.5f)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            yield return null;
        }

        canShoot = true;
        StartCoroutine(ShootProjectiles());
    }

    IEnumerator ShootProjectiles()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            StartCoroutine(FireAnimation()); // Trigger sprite change when shooting
        }
    }

    IEnumerator FireAnimation()
    {
        spriteRenderer.sprite = fireSprite; // Change to firing sprite
        Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f); // Brief delay to show firing sprite
        spriteRenderer.sprite = normalSprite; // Switch back to normal sprite
    }
}
