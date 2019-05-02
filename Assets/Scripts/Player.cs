using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Sprites;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float maxSpeed;
    public float jumpVelocity;

    public GameObject powerUpVisualEffect;

    // the sprites used in the running "animation"
    public Sprite left1;
    public Sprite left2;
    public Sprite right1;
    public Sprite right2;
    public Sprite defaultSprite;
    
    // this is the distance that the player has to run along the positive part of the x-axis in order to win.
    public float distanceToWin;

    private Rigidbody2D rb;
    private bool grounded = false;
    private float powerUpsCollected = 0;
    public float powerUpDuration;
    private bool powered;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Win();
    }

    // checks if the player has reached the end, won the game.
    void Win()
    {
        if (transform.position.x >= distanceToWin)
        {
            SceneManager.LoadScene("Win");
        }
    }

    void MovePlayer()
    {
        // p is short for player.
        Vector2 pPos = transform.position;
        float pScaleY = transform.lossyScale.y;
        float rightBeneathPlayer = pPos.y - (pScaleY / 2) - 0.1f;

        // will only be grounded if the player has a distance of 0.1 to the ground.
        grounded = Physics2D.Linecast(pPos, new Vector2(pPos.x, rightBeneathPlayer), 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetKeyDown("w") && grounded)
        {
            rb.AddForce(new Vector2(0, jumpVelocity));
        }
        if (Input.GetKey("a") && Mathf.Abs(rb.velocity.x) < maxSpeed)
        {
            rb.AddForce(new Vector2(-movementSpeed, 0));
            StartCoroutine(Left());
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
        }
        //if (Input.GetKey("s"))
        //{
        // not implemented.
        //}
        if (Input.GetKey("d") && Mathf.Abs(rb.velocity.x) < maxSpeed)
        {
            rb.AddForce(new Vector2(movementSpeed, 0));
            StartCoroutine(Right());
        }
    }

    IEnumerator Right()
    {
        while (Input.GetKey("d"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = right1;
            yield return new WaitForSeconds(0.3f);
            gameObject.GetComponent<SpriteRenderer>().sprite = right2;
            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator Left()
    {
        while (Input.GetKey("a"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = left1;
            yield return new WaitForSeconds(0.3f);
            gameObject.GetComponent<SpriteRenderer>().sprite = left2;
            yield return new WaitForSeconds(0.3f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PowerUp")
        {
            powerUpsCollected++;

            Instantiate(powerUpVisualEffect, other.gameObject.transform.position, Quaternion.identity);

            StartCoroutine(SuperSpeed());

            Destroy(other.gameObject);
        }
    }

    // The superspeed effect does not stack when collecting more powerUps, this is to avoid the player going too fast. The duration of the powerups does not stack either.
    IEnumerator SuperSpeed() {
        float originMaxSpeed = maxSpeed;
        float originMovementSpeed = movementSpeed;
        float originJumpVelocity = jumpVelocity;

        if (powered == false)
        {
            jumpVelocity += (originJumpVelocity / 2);
            maxSpeed += originMaxSpeed;
            movementSpeed += originMovementSpeed;
            powered = true;
            yield return new WaitForSeconds(powerUpDuration);
            maxSpeed -= originMaxSpeed;
            movementSpeed -= originMovementSpeed;
            jumpVelocity -= (originJumpVelocity / 2);
            powered = false;
        }
    }
}
