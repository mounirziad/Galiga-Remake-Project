using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bottomEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, 0f));

        // Despawns enemy bullets
        if (gameObject.transform.position.y <= bottomEdge.y - 1.0f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.CompareTag("Player"))
        {
            Destroy(whatDidIHit.gameObject);
            Destroy(gameObject);
            GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameController");
            GameManager gameManager = gameManagerObject.GetComponent<GameManager>();
            // Call the RespawnPlayer function in the GameManager
            gameManager.RespawnPlayer();
        }
    }
}
