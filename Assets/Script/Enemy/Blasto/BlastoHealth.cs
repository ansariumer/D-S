using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BlastoHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;

    private int currentHealth;
    public BlastoKill blastoKill;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public ParticleSystem dieEffect;
    public SpawnManager spawnManager;

    void Awake()
    {
        currentHealth = maxHealth;
        slider.maxValue = currentHealth;
        slider.value = currentHealth;
        fill.color = gradient.Evaluate(1f);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        if (currentHealth <= 0)
        {
            //blastoKill.Blast();
            spawnManager.healthSpawn(transform.position); // spawns at this exact pos
            Play();
            Destroy(gameObject);
        }
    }

    public void Play()
    {
        Instantiate(dieEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
