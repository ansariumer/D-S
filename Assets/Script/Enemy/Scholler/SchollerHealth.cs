using UnityEngine;
using UnityEngine.UI;

public class SchollerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 3f;

    private float currentHealth;
    public SchollerKill schollerKill;

    public Slider slider;
    public Gradient gradient; // will create a gradint bar
    public Image fill;

    void Awake()
    {
        currentHealth = maxHealth;
        slider.maxValue = currentHealth;
        slider.value = currentHealth;
        fill.color = gradient.Evaluate(1f);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        
        slider.value = currentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue); 

        if (currentHealth <= 0)
        {
            schollerKill.Blast();
        }
    }
}
