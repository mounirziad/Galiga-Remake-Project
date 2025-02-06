using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{ 

    public int score = 0;
    private int oneUpScore = 20000;
    private bool oneUpFlag = false;
    private int enemiesAlive;
    private int prevEnemiesAlive;
    [SerializeField] TextMeshProUGUI scoreText; // The TextMeshPro object to display

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemyManagerObject = GameObject.Find("Enemies");
        EnemyManager enemyManager = enemyManagerObject.GetComponent<EnemyManager>();
        enemiesAlive = enemyManager.totalEnemies;
    }

    // Update is called once per frame
    void Update()
    {



        if (score > oneUpScore && oneUpFlag == false)
        {
            // playerLives += 1;
        }

        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameController");
        GameManager gameManager = gameManagerObject.GetComponent<GameManager>();
        enemiesAlive = gameManager.enemiesAlive;

        Debug.Log(enemiesAlive + "    " + score);
        scoreText.text = score.ToString();
    }

}
