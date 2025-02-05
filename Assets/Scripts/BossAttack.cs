using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject projectilePrefab; // Default projectile (seeds)
    public GameObject laserPrefab; // Laser attack prefab
    public Transform firePoint;
    public float fireRate = 1.5f;

    public Sprite normalSprite;  // Default boss sprite
    public Sprite fireSprite;    // Firing sprite
    private SpriteRenderer spriteRenderer;

    private bool isShooting = false;
    private Coroutine attackCoroutine;

    void Start()
    {
        isShooting = false;
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the sprite renderer
    }

    public void StartShooting()
    {
        if (!isShooting)
        {
            isShooting = true;
            attackCoroutine = StartCoroutine(AttackRoutine());
        }
    }

    public void StopShooting()
    {
        if (isShooting)
        {
            isShooting = false;
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
            }
            spriteRenderer.sprite = normalSprite; // Reset to normal sprite
        }
    }

    public void SwitchToLaser()
    {
        projectilePrefab = laserPrefab; // Swap the projectile to the laser
    }

    IEnumerator AttackRoutine()
    {
        while (isShooting)
        {
            spriteRenderer.sprite = fireSprite; // Change to firing sprite
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            yield return new WaitForSeconds(0.1f); // Show fire sprite briefly
            spriteRenderer.sprite = normalSprite; // Switch back to normal sprite

            yield return new WaitForSeconds(fireRate - 0.1f); // Wait for next shot
        }
    }
}
