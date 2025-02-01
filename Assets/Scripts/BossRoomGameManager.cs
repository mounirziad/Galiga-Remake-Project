using System.Collections;
using UnityEngine;

public class BossRoomGameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject bossPrefab;
    public Transform playerSpawnpoint;
    public Transform bossSpawnpoint;
    private GameObject playerInstance;
    private GameObject bossInstance;

    void Start()
    {
        SpawnPlayer();
        StartCoroutine(SpawnBossSequence());
    }

    void SpawnPlayer()
    {
        playerInstance = Instantiate(playerPrefab, playerSpawnpoint.position, playerSpawnpoint.rotation);
        playerInstance.GetComponent<PlayerController>().isFrozen = true; // Freeze player at start
    }

    IEnumerator SpawnBossSequence()
    {
        bossInstance = Instantiate(bossPrefab, bossSpawnpoint.position, bossSpawnpoint.rotation);
        yield return new WaitForSeconds(3.0f); // Wait for boss to complete intro

        // Unfreeze player after boss finishes its movement
        playerInstance.GetComponent<PlayerController>().Unfreeze();
    }
}
