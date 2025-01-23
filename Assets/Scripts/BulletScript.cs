using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
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
        if (whatDidIHit.CompareTag("Enemy"))
        {
            Destroy(whatDidIHit.gameObject);
            Destroy(gameObject);
        }
        else if (whatDidIHit.CompareTag("Player"))
        {
            Destroy(whatDidIHit.gameObject);
            Destroy(gameObject);
            GameObject gameManagerObject = GameObject.Find("Game Manager");
            GameManager gameManager = gameManagerObject.GetComponent<GameManager>();
            // Call the RespawnPlayer function in the GameManager
            gameManager.RespawnPlayer();
        }

    }
}
