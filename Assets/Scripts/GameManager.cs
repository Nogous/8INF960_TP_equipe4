using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI coinText;

    // condition victoire défaite
    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private GameObject loseScreen;

    [SerializeField]
    private float levelDuration = 120f;
    private float currentTime = 0f;

    public bool levelEnd = false;
    public bool winLevel = false;

    // coins
    public int nbCoin = 0;

    // enneimie
    public float InitSpeedEnemie = 1f;
    public float speedEnemie = 1f;

    public float couldawnEnnemieSpeed = 0f;
    public float TimeEnnemieSlow = 10f;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        currentTime = levelDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelEnd)
        {
            if (winLevel)
                winScreen.SetActive(true);
            else
                loseScreen.SetActive(true);

            return;
        }

        GameTimerUpdate();

        if (InitSpeedEnemie != speedEnemie)
        {
            UpdateSpeedEnnemie();
        }
    }

    private void GameTimerUpdate()
    {
        currentTime -= Time.deltaTime;
        
        int tmp = (int)currentTime / 60;

        countdownText.text = "Time left : " + tmp.ToString("00") + ":" + (currentTime - tmp * 60).ToString("00");

        // Text color turns to red when timer is down to 5 seconds
        if (currentTime <= 5)
        {
            countdownText.color = Color.red;
            //countdownText.fontStyle = FontStyle.Bold;
        }

        // Prevent timer from being negative
        if (currentTime <= 0)
        {
            currentTime = 0;
            levelEnd = true;
            winLevel = false;
        }
    }


    //variables
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    // Set player's health values & fill healthBar
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    // Update healthBar
    public void SetHealth(int health)
    {
        if (health<=0)
        {
            levelEnd = true;
            winLevel = false;
        }

        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void AddCoin(int i = 1)
    {
        nbCoin += i;
        coinText.text = nbCoin.ToString("0");
    }

    public void PickupBonus()
    {
        speedEnemie = InitSpeedEnemie/3;
        couldawnEnnemieSpeed = TimeEnnemieSlow;
    }

    public void UpdateSpeedEnnemie()
    {
        couldawnEnnemieSpeed -= Time.deltaTime;
        if (couldawnEnnemieSpeed <= 0) 
        {
            speedEnemie = InitSpeedEnemie;
        }
    }
}
