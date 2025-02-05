using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy[] prefabs;
    public int rows = 5;
    public int columns = 11;
    public float speed = 1.0f;
    public Vector3 direction = Vector2.right;
    public int totalEnemies => rows * columns;

    private void Awake()
    {
        // Sets up grid of enemies
        for (int row = 0; row < this.rows; row++)
        {
            float width = 1.25f * (this.columns - 1);
            float height = (1.25f * (this.rows - 1)) + 2;
            Vector3 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 1.25f), 0.0f);

            for (int col = 0; col < this.columns; col++)
            {
                Enemy enemy = Instantiate(this.prefabs[row], this.transform);
                Vector3 position = rowPosition;
                position.x += col * 1.25f;
                enemy.transform.localPosition = position;
            }
        }
    }

    private void Update()
    {
        this.transform.position += direction * this.speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        // Iterates through each enemy game object to check if they are at camera edge
        foreach (Transform enemy in this.transform)
        {
            // Switches movement direction when hitting an edge
            if (direction == Vector3.right && enemy.position.x >= (rightEdge.x - 1.0f))
            {
                direction.x *= -1.0f;
            }
            else if (direction == Vector3.left && enemy.position.x <= (leftEdge.x + 1.0f))
            {
                direction.x *= -1.0f;
            }
        }
    }
}
