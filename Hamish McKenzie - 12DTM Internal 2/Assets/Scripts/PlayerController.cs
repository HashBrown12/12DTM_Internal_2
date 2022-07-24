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
        // Vector 3 forward is used here because I had to rotate the player model
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * movementSpeed);

        // if statement to make the player jump when input is recieved
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, pathTwo);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, pathOne);
        }
    }

    // a function which deals with all of the collisions in the game
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
