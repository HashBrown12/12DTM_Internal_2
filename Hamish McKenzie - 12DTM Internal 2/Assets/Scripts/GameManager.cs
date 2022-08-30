using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Variables
    private int playerHealth;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 1;
        healthText.text = "Health: " + playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
