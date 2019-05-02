using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // i basically reused SpawnManager as I deemed it sufficient. Except that i use the y coordinate of the player at the start of the game.
    public int maxEnemies;
    public Transform playerPos;
    public GameObject enemy;
    public float horizontalMin;
    public float horizontalMax;

    private Vector2 originPosition;

    // Start is called before the first frame update
    void Start()
    {
        originPosition = new Vector2(transform.position.x, playerPos.position.y);
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            Vector2 randomPosition = originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), playerPos.position.y);
            Instantiate(enemy, randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }
    }
}
