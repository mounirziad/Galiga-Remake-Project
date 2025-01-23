using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public Transform playerSpawnpoint;
    public Transform enemySpawnpoint;
    private int playerLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
        SpawnEnemy();
    }

    void Update()
    {

    }

    void SpawnPlayer() //Spawns player
    {
        Instantiate(player, playerSpawnpoint.position, playerSpawnpoint.rotation);
    }

    void SpawnEnemy() //Spawns enemies
    {
        Instantiate(enemy, enemySpawnpoint.position, enemySpawnpoint.rotation);
    }

    public void RespawnPlayer()
    {
        SpawnPlayer();
        playerLives--;
        Debug.Log("Player lives: " + playerLives);
    }
}
