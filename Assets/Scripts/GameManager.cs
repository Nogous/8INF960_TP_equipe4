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
    private bool endSoundPlayed;

    [SerializeField]
    private float levelDuration = 120f;
    private float currentTime = 0f;

    public bool levelEnd = false;
    public bool winLevel = false;

    // coins
    public int nbCoin = 0;

    // ennemis
    public float InitSpeedEnemie = 1f;
    public float speedEnemie = 1f;

    private float cooldownEnnemieSpeed = 0f;
    public float TimeEnnemieSlow = 10f;

    // pause
    public GameObject pauseMenu;

    // potion
    public Transform[] potionPositions;
    public GameObject potionPrefab;

    // variable d'affichage du timer
    public Slider slider;
    public Gradient gradient;
    public Image fill;

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
        pauseMenu.SetActive(false);
        endSoundPlayed = false;

        // generation d'un nombre random de potions de facon random sur les diferant points de spawn de potions
        List<int> tab = new List<int>();    // positions possible
        int i;
        for (i = 0; i < potionPositions.Length; i++)
        {
            tab.Add(i);
        }

        for (i = Random.Range(1, potionPositions.Length); i-- > 0;)   // nombre de potion a cree
        {
            int j = Random.Range(0, tab.Count);     // choix de la position de la nouvelle potion
            GameObject tmpObj = Instantiate(potionPrefab);
            tmpObj.transform.position = potionPositions[tab[j]].position;
            tab.RemoveAt(j);
        }

        // initialisation de la duree max du niveau
        currentTime = levelDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelEnd && !endSoundPlayed)
        {
            // victoire
            if (winLevel)
            {
                SoundManager.instance.PlaySound("Win");
                winScreen.SetActive(true);
            }
            // defaite
            else
            {
                SoundManager.instance.PlaySound("Game Over");
                loseScreen.SetActive(true);
            }
            Time.timeScale = 0f;
            endSoundPlayed = true;
            return;
        }

        GameTimerUpdate();

        if (InitSpeedEnemie != speedEnemie)
        {
            UpdateSpeedEnnemie();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }

    // gestion de l'affichage du temps restant pour finir le level
    private void GameTimerUpdate()
    {
        currentTime -= Time.deltaTime;
        
        int tmp = (int)currentTime / 60;

        // separation de l'affichage en minute : seconde
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
        cooldownEnnemieSpeed = TimeEnnemieSlow;
    }

    public void UpdateSpeedEnnemie()
    {
        cooldownEnnemieSpeed -= Time.deltaTime;
        // retour a une vitesse normal pour les ennemis
        if (cooldownEnnemieSpeed <= 0) 
        {
            speedEnemie = InitSpeedEnemie;
        }
    }

    public void BackToGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
