using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 3f;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Awake()
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
    public void PlayerDamage(int damage)
    {
        health -= damage;
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
