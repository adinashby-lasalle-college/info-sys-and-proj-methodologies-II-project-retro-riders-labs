using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IChannel
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider easeHealthSlider;
    private float health;
    private float lerpSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        health = HealthSystem.Singleton.maxHealth;
        HealthSystem.Singleton.AddObserver(this);
    }

    public void Updates(int newHealth)
    {
        this.health = newHealth;
        health /= 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }
        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
        }

    }
}
