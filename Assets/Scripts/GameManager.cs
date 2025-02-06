using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject BossShield;
    public GameObject player;
    public GameObject boss;
    public Transform playerSpawnpoint;
    public Transform bossSpawnpoint;
    public int enemiesAlive;
    private GameObject bossInstance;
    private GameObject playerInstance;
    Scene currentScene;
    private bool firstSpawn;
    public int enemiesdestroyed;
    public GameObject lifePrefab;
    private GameObject[] lives; // Array to store life objects
    public int totalLives = 3;
    private int playerLives;

    void Start()
    {
        firstSpawn = true;
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "GeneralCombat")
        {
            GameObject enemyManagerObject = GameObject.Find("Enemies");
            EnemyManager enemyManager = enemyManagerObject.GetComponent<EnemyManager>();
            enemiesAlive = enemyManager.totalEnemies;
            SpawnPlayer();
        }
        else if (currentScene.name == "Boss")
        {
            GameObject enemySpawn1 = GameObject.Find("EnemySpawnpoint1");
            GameObject enemySpawn2 = GameObject.Find("EnemySpawnpoint2");

            EnemyManager enemyManager1 = enemySpawn1.GetComponent<EnemyManager>();
            EnemyManager enemyManager2 = enemySpawn2.GetComponent<EnemyManager>();

            enemiesAlive = enemyManager1.totalEnemies + enemyManager2.totalEnemies;

            SpawnPlayer();
            StartCoroutine(SpawnBossSequence());
        }

        lives = new GameObject[playerLives];
        playerLives = totalLives;

        for (int i = 0; i < totalLives; i++)
        {
            // Position the lives with a small gap
            Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(0.05f + (i * 0.05f), 0.02f, 5f));
            lives[i] = Instantiate(lifePrefab, position, Quaternion.identity);
        }
    }

    void Update()
    {
        DestroyBossShield();

        // Check if enemiesdestroyed has reached 48
        if (currentScene.name == "GeneralCombat")
        {

            if ((GameObject.FindGameObjectsWithTag("AppleEnemy").Length == 0 && GameObject.FindGameObjectsWithTag("CookieEnemy").Length == 0 && GameObject.FindGameObjectsWithTag("PineappleEnemy").Length == 0))
            {
                StartCoroutine(LoadNextSceneAfterDelay(3f)); // Wait 3 seconds before loading the next scene
            }
        }
    }


    void SpawnPlayer()
    {
        playerInstance = Instantiate(player, playerSpawnpoint.position, playerSpawnpoint.rotation);

        if (currentScene.name == "Boss" && firstSpawn)
        {
            firstSpawn = false;
            playerInstance.GetComponent<PlayerController>().isFrozen = true;
        }
    }

    public void RespawnPlayer()
    {
        SpawnPlayer();
        playerLives--;
        Debug.Log("Player lives: " + playerLives);

        if (playerLives > 0)
        {
            Destroy(lives[playerLives]);
        }

        if (playerLives < 0)
        {
            StartCoroutine(TransitionToGameOver());
        }
    }

    private IEnumerator TransitionToGameOver()
    {
        // Load the GameOver scene
        SceneManager.LoadScene("GameOver");

        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // Return to the Menu scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Menu");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

    }

    IEnumerator SpawnBossSequence()
    {
        bossInstance = Instantiate(boss, bossSpawnpoint.position, bossSpawnpoint.rotation);

        Transform shieldTransform = bossInstance.transform.Find("CitrusShield");

        if (shieldTransform != null)
        {
            BossShield = shieldTransform.gameObject;
        }
        else
        {
            Debug.LogWarning("BossShield not found! Make sure it exists in the boss prefab.");
        }

        yield return new WaitForSeconds(3.0f);

        playerInstance.GetComponent<PlayerController>().Unfreeze();
    }

    public void DestroyBossShield()
    {
        if (enemiesdestroyed == 16 && BossShield != null)
        {
            Destroy(BossShield);

            // Switch boss attack to laser mode
            BossAttack bossAttack = bossInstance.GetComponent<BossAttack>();
            if (bossAttack != null)
            {
                bossAttack.SwitchToLaser();
            }
        }
    }

    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        LoadNextScene(); // Load the next scene
    }

    void LoadNextScene()
    {
        // Replace "NextSceneName" with the name of your next scene
        SceneManager.LoadScene("Cutscene2");
    }
}