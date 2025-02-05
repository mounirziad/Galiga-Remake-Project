using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Enemy_Pineapple : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 direction = Vector2.down;
    public float minDelay = 10.0f;
    public float maxDelay = 30.0f;
    public int numSections = 3;
    GameObject scoreManagerObject;
    ScoreScript scoreScript;

    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        scoreManagerObject = GameObject.Find("ScoreManager");
        scoreScript = scoreManagerObject.GetComponent<ScoreScript>();
        StartCoroutine(StartMovingAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Launch();
        }

        // Destroys enemy after all sections have been destroyed
        if (numSections == 0)
        {
            Destroy(gameObject);
        }

        Vector3 bottomEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, 0f));

        // Despawns enemy when off screen
        if (gameObject.transform.position.y <= bottomEdge.y - 1.0f)
        {
            GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameController");
            GameManager gameManager = gameManagerObject.GetComponent<GameManager>();
            gameManager.enemiesAlive--;
            Destroy(gameObject);
        }
    }

    void Launch()
    {
        transform.position += direction * this.speed * Time.deltaTime;
        Debug.Log("GO");
    }

    // Launches the enemy after a random interval between 10s and 30s
    IEnumerator StartMovingAfterDelay()
    {
        float delay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(delay);

        isMoving = true;

        transform.SetParent(null);
    }

    public void addSectionPoints()
    {
        scoreScript.score += 100;
    }
}
