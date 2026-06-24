using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 3f;

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
