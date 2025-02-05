using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    public Transform playerSpawnpoint;
    public Transform bossSpawnpoint;
    private int playerLives = 3;
    public int enemiesAlive;
    private GameObject bossInstance;
    private GameObject playerInstance;
    Scene currentScene;
    private bool firstSpawn;

    // Start is called before the first frame update
    void Start()
    {
        firstSpawn = true;
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "SampleScene")
        {
            GameObject enemyManagerObject = GameObject.Find("Enemies");
            EnemyManager enemyManager = enemyManagerObject.GetComponent<EnemyManager>();
            enemiesAlive = enemyManager.totalEnemies;
            SpawnPlayer();
        }
        else if (currentScene.name == "Scene2")
        {
            GameObject enemySpawn1 = GameObject.Find("EnemySpawnpoint1");
            GameObject enemySpawn2 = GameObject.Find("EnemySpawnpoint2");

            EnemyManager enemyManager1 = enemySpawn1.GetComponent<EnemyManager>();
            EnemyManager enemyManager2 = enemySpawn2.GetComponent<EnemyManager>();

            enemiesAlive = enemyManager1.totalEnemies + enemyManager2.totalEnemies;

            SpawnPlayer();
            StartCoroutine(SpawnBossSequence());
        }
    }

    void Update()
    {

    }

    void SpawnPlayer() //Spawns player
    {
        playerInstance = Instantiate(player, playerSpawnpoint.position, playerSpawnpoint.rotation);

        if (currentScene.name == "Scene2" && firstSpawn)
        {
            firstSpawn = false;
            playerInstance.GetComponent<PlayerController>().isFrozen = true; // Freeze player at start
        }
    }

    public void RespawnPlayer()
    {
        SpawnPlayer();
        playerLives--;
        Debug.Log("Player lives: " + playerLives);
    }

    IEnumerator SpawnBossSequence()
    {
        bossInstance = Instantiate(boss, bossSpawnpoint.position, bossSpawnpoint.rotation);
        yield return new WaitForSeconds(3.0f); // Wait for boss to complete intro

        // Unfreeze player after boss finishes its movement
        playerInstance.GetComponent<PlayerController>().Unfreeze();
    }
}
