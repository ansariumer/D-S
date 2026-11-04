using UnityEngine;
using UnityEngine.UI;

public class BlastoHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;

    private int currentHealth;
    public BlastoKill blastoKill;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

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
            blastoKill.Blast();
        }
    }
}
