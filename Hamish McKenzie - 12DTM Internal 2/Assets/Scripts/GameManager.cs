using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Variables
    public int playerHealth;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI youWinText;
    public TextMeshProUGUI speedText;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        // Setting the player health to one before the game begins
        playerHealth = 1;
        UpdateHealth(0);

        // Making a reference to the PlayerController script
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
        {
        // an if statement to bring up the game over text when the player's health reaches 0
        if(playerHealth <= 0)
        {
            gameOverText.gameObject.SetActive(true);
        }

        // Code that references the player's horizontal speed from the PlayerController script
        // to display it as a percentage
        speedText.text = "Speed: " + playerController.horizontalInput * 100 + "%";
    }

    // A function which updates the health of the player if they get the power up
    public void UpdateHealth(int healthToAdd)
    {
        playerHealth += healthToAdd;
        healthText.text = "Health: " + playerHealth;
    }

    // A function which displays the winning text when the player beats the game
    public void YouWin(bool youWin)
    {
        if(youWin = true)
        {
            youWinText.gameObject.SetActive(true);
        }
    }
}
