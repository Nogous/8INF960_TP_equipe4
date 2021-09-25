// Libraries
using UnityEngine;
using UnityEngine.UI;

//Ajouter le script au Gamecomponent Player + renseigner Health Bar !!!

public class PlayerHealth : MonoBehaviour
{
    // Variables
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Set player's health values & fill healthBar (called before the first frame update)
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth (maxHealth);
    }

    // Update health value when player takes damage
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
