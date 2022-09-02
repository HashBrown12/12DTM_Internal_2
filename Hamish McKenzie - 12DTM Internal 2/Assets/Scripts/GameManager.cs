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
    {
        if(playerHealth == 0)
        {
            gameOverText.gameObject.SetActive(true);
        }
    }

    public void UpdateHealth(int healthToAdd)
    {
        playerHealth += healthToAdd;
        healthText.text = "Health: " + playerHealth;
    }
}
