using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomGameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public Transform playerSpawnpoint;
    public Transform enemySpawnpoint;
    private int playerLives = 3;
    public Transform BossSpawnPoint;
    public GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
        SpawnBoss();
        SpawnPlayer();

    }

    // Update is called once per frame
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
    void SpawnBoss()
    {
        Instantiate(Boss, BossSpawnPoint.position, BossSpawnPoint.rotation);

    }

    public void RespawnPlayer()
    {
        SpawnPlayer();
        playerLives--;
        Debug.Log("Player lives: " + playerLives);
    }

}
