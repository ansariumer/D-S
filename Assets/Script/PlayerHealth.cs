using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    //[SerializeField]
    public float health = 3f;

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GameOver gameOver;
    public CameraShake camShake;
    public ShakeHealthBar shakeHealthBar;

    public GameObject damageNumber;
    public Transform numbSpawnPoint;

    public ParticleSystem damageEffect;

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

        if (damageNumber != null && numbSpawnPoint != null)
        {
            GameObject numObj = Instantiate(damageNumber, numbSpawnPoint.position, Quaternion.identity);
            DamageNumber fn = numObj.GetComponent<DamageNumber>();
            if (fn != null)
            {
                fn.SetDamage(damage);
            }
        }
        else
        {
            Debug.LogError("The DamageNumber script is missing from the spawned prefab!");
        }
        
        damageEffect.Play(); //partical

        camShake.ShakeCamera(); // camera shake

        if(damage > 1)
        {
            shakeHealthBar.shakeHealth(); // health bar shake
        }

        if (health <= 0)
        {
            gameOver.GameOverP();
            Destroy(gameObject);
        }
    }
}
