using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    // i basically reused SpawnManager as I deemed it sufficient.
    public int maxPowerUps;
    public GameObject powerUp;
    public float horizontalMin;
    public float horizontalMax;
    public float verticalMin;
    public float verticalMax;

    private Vector2 originPosition;

    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        for (int i = 0; i < maxPowerUps; i++)
        {
            Vector2 randomPosition = originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
            Instantiate(powerUp, randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }
    }
}
