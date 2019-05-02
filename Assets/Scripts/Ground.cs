using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Script with the purpose of extending the terrain/ground whenever the player is nearing the edge of it.
    // Currently extends the ground in both directions.

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Extend();
    }

    void Extend()
    {
        float sizeY = gameObject.transform.lossyScale.y;
        float sizeZ = gameObject.transform.lossyScale.z;
        float groundLength = gameObject.transform.lossyScale.x;
        float halfGroundLength = groundLength / 2;
        float maxDistToEdge = gameObject.transform.lossyScale.x / 5;
        //Vector3 groundPos = gameObject.transform.position;

        if (player.transform.position.x >= halfGroundLength - maxDistToEdge || player.transform.position.x <= -halfGroundLength + maxDistToEdge)
        {
            gameObject.transform.localScale = new Vector3(groundLength + halfGroundLength, sizeY, sizeZ);
        }
    }
}
