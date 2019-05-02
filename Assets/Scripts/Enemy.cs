using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Patrol", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject)

            // i found it was best to make the player stop instead of destroying the player gameObject, as that also destroys the camera attached to it.
            Destroy(collision.gameObject.transform);
            Destroy(collision.rigidbody);
            SceneManager.LoadScene("GameOver");
        }
    }

    // Wont patrol the same distance back and forth. It will move around in a random way. And only on the ground not on the platforms.
    void Patrol()
    {
        transform.Translate(new Vector2(Random.Range(-1, 2), 0));
    }
}
