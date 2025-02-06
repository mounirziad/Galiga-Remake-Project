using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pineapple_Section : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameController");
        GameManager gameManager = gameManagerObject.GetComponent<GameManager>();
        Enemy_Pineapple enemyPineapple = GetComponentInParent<Enemy_Pineapple>();

        if (enemyPineapple.isCounted) // Skip if already counted
        {
            return;
        }

        if (whatDidIHit.CompareTag("Player"))
        {
            enemyPineapple.isCounted = true; // Mark as counted
            gameManager.enemiesAlive--;
            gameManager.enemiesdestroyed++;
            Destroy(whatDidIHit.gameObject);
            Destroy(enemyPineapple.gameObject);
            gameManager.RespawnPlayer();
        }
        else if (whatDidIHit.CompareTag("PlayerBullet"))
        {

            Destroy(whatDidIHit.gameObject);

            // Reduce number of sections left
            enemyPineapple.numSections--;
            enemyPineapple.addSectionPoints();

            // Only decrement enemiesAlive and increment enemiesdestroyed when the whole pineapple is destroyed
            if (enemyPineapple.numSections == 0)
            {
                enemyPineapple.isCounted = true; // Mark as counted
                gameManager.enemiesAlive--;
                Destroy(enemyPineapple.gameObject);
            }

            Destroy(gameObject);
        }
    }
}