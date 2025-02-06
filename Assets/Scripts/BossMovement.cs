using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMovement : MonoBehaviour
{
    public float bossHealth = 20f;
    public float moveSpeed;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 1.5f;
    private bool canShoot = false;
    private Vector3 direction = Vector2.right;
    public Sprite normalSprite;  // Default boss sprite
    public Sprite fireSprite;    // Firing sprite
    private SpriteRenderer spriteRenderer;
    Scene currentScene;
    private BossAttack bossAttack; // Reference to BossAttack script

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the sprite renderer
        bossAttack = GetComponent<BossAttack>(); // Get the BossAttack component
        StartCoroutine(BossIntroSequence());
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (canShoot)
        {
            this.transform.position += direction * this.moveSpeed * Time.deltaTime;

            Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

            // Switches movement direction when hitting an edge
            if (direction == Vector3.right && transform.position.x >= (rightEdge.x - 1.5f))
            {
                direction.x = -1.0f;
            }
            else if (direction == Vector3.left && transform.position.x <= (leftEdge.x + 1.5f))
            {
                direction.x = 1.0f;
            }
        }

        if (bossHealth <= 0)
        {
            SceneManager.LoadScene("Victory");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            moveSpeed *= -1;
        }

        if (collision.gameObject.tag == "PlayerBullet")
        {
            bossHealth = bossHealth - 1;
        }
    }

    IEnumerator BossIntroSequence()
    {
        while (transform.position.y > 10f)
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        while (transform.position.y < 13f)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            yield return null;
        }

        canShoot = true;
        bossAttack.StartShooting(); // Start the attack routine
    }

}