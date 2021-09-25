using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //  public float speed = 0;
    public TextMeshProUGUI countText;

    public GameObject winTextObject;
    public GameObject loseTextObjet;

    private float currentTime = 0f;
    private float startingTime = 10f;

    // private Rigidbody rb;
    private int count;

    // private float movementX;
    // private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        currentTime = startingTime;

        SetCountText();
        winTextObject.SetActive(false);
        loseTextObjet.SetActive(false);
    }

    // private void OnMove(InputValue movementValue)
    // {
    //     Vector2 movementVector = movementValue.Get<Vector2>();
    //     movementX = movementVector.x;
    //     movementY = movementVector.y;
    // }
    void SetCountText()
    {
        countText.text = "Count " + count.ToString();
        // if (count >= 12)
        // {
        //     YouWin();
        // }
    }

    // void FixedUpdate()
    // {
    //     Vector3 movement = new Vector3(movementX, 0.0f, movementY);
    //     rb.AddForce(movement*speed);
    // }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Countdown();
    }

    private void Countdown()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            YouLose();
        }
    }
    
    private void YouWin()
    {
        winTextObject.SetActive(true);
    }

    private void YouLose()
    {
        loseTextObject.SetActive(true);
    }
}
