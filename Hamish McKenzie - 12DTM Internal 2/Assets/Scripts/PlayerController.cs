using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // variables
    private Rigidbody playerRb;
    public float horizontalInput;
    public float movementSpeed = 8.0f;
    public float jumpForce = 7.0f;
    public bool isOnGround = true;
    public float pathOne = -1.0f;
    public float pathTwo = 1.25f;

    // Start is called before the first frame update
    void Start()
    {
        // Getting the component for the player rigidbody
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // code that recieves horizontal inputs and moves the player accordingly
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * movementSpeed);

        // if statement to make the player jump when input is recieved
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerRb.velocity = new Vector3(0, 0, 5);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerRb.velocity = new Vector3(0, 0, -5);
        }

        if(transform.position.z < pathOne)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, pathOne); 
        }

        if(transform.position.z > pathTwo)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, pathTwo);
        }

    }

    // a function which deals with all of the collisions in the game
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Path_1_Obstacle"))
        {
            playerRb.velocity = new Vector3(0, 0, 5);
        }

        if (collision.gameObject.CompareTag("Path_2_Obstacle"))
        {
            playerRb.velocity = new Vector3(0, 0, -5);
        }
    }
}

