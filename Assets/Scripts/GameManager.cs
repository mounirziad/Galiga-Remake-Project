using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject lifePrefab;
    public Transform playerSpawnpoint;
    public Transform enemySpawnpoint;
<<<<<<< Updated upstream
    private int playerLives = 3;
=======
    private GameObject[] lives; // Array to store life objects
    public int totalLives = 3;
    private int playerLives;
    public int enemiesAlive;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
<<<<<<< Updated upstream
        SpawnEnemy();
=======

        lives = new GameObject[playerLives];
        playerLives = totalLives;

        for (int i = 0; i < totalLives; i++)
        {
            // Position the lives with a small gap
            Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(0.05f + (i * 0.05f), 0.02f, 5f));
            lives[i] = Instantiate(lifePrefab, position, Quaternion.identity);
        }
>>>>>>> Stashed changes
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

        if(playerLives > 0)
        {
            Destroy(lives[playerLives]);
        }

        if(playerLives < 0)
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

}
