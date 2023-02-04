using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float slidingTime = 0.5f;

    public void SetHealth(int health)
    {
        //slider.value = health;
        slider.DOValue(health, slidingTime);
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        //slider.value = maxHealth;
        slider.DOValue(maxHealth, slidingTime);
    }
}
