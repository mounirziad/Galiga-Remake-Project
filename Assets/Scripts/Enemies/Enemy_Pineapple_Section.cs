using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pineapple_Section : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.CompareTag("Player"))
        {
            Destroy(whatDidIHit.gameObject);
            Destroy(transform.parent.gameObject);
            GameObject gameManagerObject = GameObject.Find("Game Manager");
            GameManager gameManager = gameManagerObject.GetComponent<GameManager>();
            // Call the RespawnPlayer function in the GameManager
            gameManager.RespawnPlayer();
        }
        else if (whatDidIHit.CompareTag("PlayerBullet"))
        {
            Enemy_Pineapple enemyPineapple = GetComponentInParent<Enemy_Pineapple>();
            enemyPineapple.numSections --;
            Destroy(whatDidIHit.gameObject);
            Destroy(gameObject);
        }
    }
}
