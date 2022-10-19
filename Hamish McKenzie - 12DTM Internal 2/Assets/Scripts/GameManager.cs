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
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 1;
        UpdateHealth(0);
    }

    // Update is called once per frame
    void Update()
    {   // an if statement to bring up the game over text when the player's health reaches 0
        if(playerHealth == 0)
        {
            gameOverText.gameObject.SetActive(true);
        }
    }

    // A function which updates the health of the player if they get the power up
    public void UpdateHealth(int healthToAdd)
    {
        playerHealth += healthToAdd;
        healthText.text = "Health: " + playerHealth;
    }
}
