using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    private Rigidbody playerRb;
    public float horizontalInput;
    public float movementSpeed = 8.0f;
    public float jumpForce = 7.0f;
    public bool isOnGround = true;
    public float pathOne = -1.0f;
    public float pathTwo = 1.25f;
    public float leftBarrier = -5.0f;
    public float rightBarrier = 95.0f;
    public bool hasPowerup;
    public bool doubleJump;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Getting the component for the player rigidbody
        playerRb = GetComponent<Rigidbody>();

        // Finding the GameManager script so it can communicate with this one
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // code that recieves horizontal inputs and moves the player accordingly
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * movementSpeed);

        // if statement to make the player jump when input is recieved
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
        }

        // If statement to make the player switch between paths
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerRb.velocity = new Vector3(0, 0, 6);
        }

        // ^^^
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerRb.velocity = new Vector3(0, 0, -6);
        }

        // If statement to make sure the player can't go off the sides of the path when switching
        if(transform.position.z < pathOne)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, pathOne); 
        }

        // ^^^
        if(transform.position.z > pathTwo)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, pathTwo);
        }

        // If statement settings barriers at the beginning and end of the level
        if(transform.position.x < leftBarrier)
        {
            transform.position = new Vector3(leftBarrier, transform.position.y, transform.position.z);
        }

        // ^^^
        if(transform.position.x > rightBarrier)
        {
            transform.position = new Vector3(rightBarrier, transform.position.y, transform.position.z);
        }

        // an if statement to disable the player controller script once the player has run out of HP
        if(gameManager.playerHealth <= 0)
        {
            enabled = false;
        }

    }

    // a function which deals with all of the for the player
    private void OnCollisionEnter(Collision collision)
    {
        // If statement to tell if the player is on the ground and if they are allowed to jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        // If statement to update player health when they collide with an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.UpdateHealth(-1);
        }
            
        // If statements to send the player back to the other path if they collide with the side of an object
        if (collision.gameObject.CompareTag("Barrier_1"))
        {
            playerRb.velocity = new Vector3(0, 0, -6);
        }

        // ^^^
        if (collision.gameObject.CompareTag("Barrier_2"))
        {
            playerRb.velocity = new Vector3(0, 0, 6);
        }

        // If statement to disable the PlayerController script when the player reaches the end
        // and enable the you win text in the GameManager script.
        if (collision.gameObject.CompareTag("Finish"))
        {
            gameManager.YouWin(true);
            enabled = false;
        }
    }

    // A function which updates the player health when they get the powerup
    // and destroys the powerup on impact
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            gameManager.UpdateHealth(1);
        }
    }
}

