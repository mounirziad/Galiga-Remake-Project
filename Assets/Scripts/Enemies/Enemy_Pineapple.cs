using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pineapple : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 direction = Vector2.down;
    public float minDelay = 10.0f;
    public float maxDelay = 30.0f;
    public int numSections = 3;

    private bool isMoving = false;
    public bool isCounted = false; // Flag to track if the enemy has been counted

    void Start()
    {
        StartCoroutine(StartMovingAfterDelay());
    }

    void Update()
    {
        if (isMoving)
        {
            Launch();
        }

        Vector3 bottomEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, 0f));

        // Despawns enemy when off screen
        if (transform.position.y <= bottomEdge.y - 1.0f)
        {
            GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameController");
            GameManager gameManager = gameManagerObject.GetComponent<GameManager>();

            if (!isCounted) // Only decrement if not already counted
            {
                gameManager.enemiesAlive--;
                gameManager.enemiesdestroyed++;
                isCounted = true; // Mark as counted
            }

            Destroy(gameObject);
        }
    }

    void Launch()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    IEnumerator StartMovingAfterDelay()
    {
        float delay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(delay);

        isMoving = true;
        transform.SetParent(null);
    }
}