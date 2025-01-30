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
    public int enemiesAlive;

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemyManagerObject = GameObject.Find("Enemies");
        EnemyManager enemyManager = enemyManagerObject.GetComponent<EnemyManager>();
        enemiesAlive = enemyManager.totalEnemies;
        SpawnPlayer();
    }

    void Update()
    {

    }

    void SpawnPlayer() //Spawns player
    {
        Instantiate(player, playerSpawnpoint.position, playerSpawnpoint.rotation);
    }

    public void RespawnPlayer()
    {
        SpawnPlayer();
        playerLives--;
        Debug.Log("Player lives: " + playerLives);
    }
}
