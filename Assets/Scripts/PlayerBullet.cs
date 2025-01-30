using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
        if (whatDidIHit.CompareTag("AppleEnemy") || whatDidIHit.CompareTag("PineappleEnemy") || whatDidIHit.CompareTag("CookieEnemy"))
        {
            GameObject gameManagerObject = GameObject.Find("Game Manager");
            GameManager gameManager = gameManagerObject.GetComponent<GameManager>();
            gameManager.enemiesAlive--;

            //Reference score int in ScoreScript

            if (whatDidIHit.CompareTag("AppleEnemy"))
            {
                //Add apple points to score
            }
            else if (whatDidIHit.CompareTag("CookieEnemy"))
            {
                //Add cookie points to score
            }
            else if (whatDidIHit.CompareTag("PineappleEnemy"))
            {
                //Add pineapplce points to score
            }
            
            Destroy(whatDidIHit.gameObject);
            Destroy(gameObject);
        }
    }
}
