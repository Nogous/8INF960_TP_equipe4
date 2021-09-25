// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    // Variables
    private float currentTime = 0f;
    private float startingTime = 60f;

    public Text countdownText;

    // Initialize timer (called before the first frame update)
    private void Start()
    {
        currentTime = startingTime;
    }

    // Decrement timer and diplay countdown texts (called once per frame)
    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = "Time left : " + currentTime.ToString("0");
        
        // Text color turns to red when timer is down to 5 seconds
        if (currentTime <= 5)
        {
            countdownText.color = Color.red;
            countdownText.fontStyle = FontStyle.Bold;
        }

        // Prevent timer from being negative
        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
}
