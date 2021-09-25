// Libraries
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Ajouter le script au Gamecomponent Player + renseigner coinsCountText, winText, loseText !!!

public class PlayerController : MonoBehaviour
{
    // Variables 
    public Text coinsCountText;
    private int coinsCount;

    public GameObject winText;
    public GameObject loseText;

    private float currentTime = 0f;
    private float startingTime = 10f;

    // Initialize coin counter and timer. Hide victory and defeat texts (called before the first frame update)
    void Start()
    {
       // rb = GetComponent<Rigidbody>();
        coinsCount = 0;
        currentTime = startingTime;

        SetCountText();
        winText.SetActive(false);
        loseText.SetActive(false);
    }

    //Display coin counter
    void SetCountText()
    {
        coinsCountText.text = coinsCount.ToString();
    }

    // Increment coin counter is collision between a coin and the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinsCount++;
        }
    }

    // Update timer and coin counter (called once per frame)
    private void Update()
    {
        Countdown();
        SetCountText();
    }

    // Display defeat text if time is up
    private void Countdown()
    {
        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0)
        {
            loseText.SetActive(true);
        }
    }
     
    // Display victory text
    private void YouWin()
    {
        winText.SetActive(true);
    }

}
