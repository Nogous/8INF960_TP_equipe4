using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Ajouter le script au Gamecomponent Player + renseigner coinsCountText, winText, loseText

public class PlayerController : MonoBehaviour
{
    //  public float speed = 0;
    public Text coinsCountText;
    private int coinsCount;

    public GameObject winText;
    public GameObject loseText;

    private float currentTime = 0f;
    private float startingTime = 10f;

    // private Rigidbody rb;

    // private float movementX;
    // private float movementY;
    // Start is called before the first frame update
    void Start()
    {
       // rb = GetComponent<Rigidbody>();
        coinsCount = 0;
        currentTime = startingTime;

        SetCountText();
        winText.SetActive(false);
        loseText.SetActive(false);
    }

    // private void OnMove(InputValue movementValue)
    // {
    //     Vector2 movementVector = movementValue.Get<Vector2>();
    //     movementX = movementVector.x;
    //     movementY = movementVector.y;
    // }
    void SetCountText()
    {
        coinsCountText.text = coinsCount.ToString();
    }

    // void FixedUpdate()
    // {
    //     Vector3 movement = new Vector3(movementX, 0.0f, movementY);
    //     rb.AddForce(movement*speed);
    // }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false); // or Destroy(other.gameObject);
            coinsCount++;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Countdown();
        SetCountText();
    }

    private void Countdown()
    {
        currentTime -= 1 * Time.deltaTime;
        // countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            YouLose();
        }
    }
    
    private void YouWin()
    {
        winText.SetActive(true);
    }

    private void YouLose()
    {
        loseText.SetActive(true);
    }
}
