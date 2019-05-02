using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int maxPlatforms;
    public GameObject platform;
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
        for(int i = 0; i < maxPlatforms; i++)
        {
            Vector2 randomPosition = originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
            Instantiate(platform, randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }
    }
}
