using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    GameObject gameManagerObject;

    void Start()
    {
        gameManagerObject = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {
        Vector3 topEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0f));

        // Despawns player bullets after crossing top of screen
        if (gameObject.transform.position.y >= topEdge.y + 1.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        // If player bullet hits an enemy, enemy and bullet are destroyed and enemiesAlive count goes down
        if (whatDidIHit.CompareTag("AppleEnemy") || whatDidIHit.CompareTag("CookieEnemy") || whatDidIHit.CompareTag("PineappleEnemy"))
        {
            GameManager gameManager = gameManagerObject.GetComponent<GameManager>();
            gameManager.enemiesAlive--;
            gameManager.enemiesdestroyed++;

            // Find the ScoreScript component and modify the score
            GameObject scoreManagerObject = GameObject.Find("ScoreManager");
            ScoreScript scoreScript = scoreManagerObject.GetComponent<ScoreScript>();

            if (whatDidIHit.CompareTag("AppleEnemy"))
            {
                //Add apple points to score
                scoreScript.score += 100; // Add apple points to score
            }
            else if (whatDidIHit.CompareTag("CookieEnemy"))
            {
                //Add cookie points to score
                scoreScript.score += 200; // Add cookie points to score
            }
            else if (whatDidIHit.CompareTag("PineappleEnemy"))
            {
                //Add pineapplce points to score
                scoreScript.score += 300; // Add pineapple points to score
            }

            Destroy(whatDidIHit.gameObject);
            Destroy(gameObject);
        }
        else if (whatDidIHit.CompareTag("Boss") || whatDidIHit.CompareTag("BossShield"))
        {
            Destroy(gameObject);
        }
    }
}