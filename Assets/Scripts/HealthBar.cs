// Libraries
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
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
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}