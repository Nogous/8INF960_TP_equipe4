using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    private float currentTime = 0f;
    private float startingTime = 10f;

    public Text countdownText;

    // Start is called before the first frame update
    private void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = "Time left : " + currentTime.ToString("0");
        

        if (currentTime <= 3)
        {
            countdownText.color = Color.red;
            countdownText.fontStyle = FontStyle.Bold;
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
}
