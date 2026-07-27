using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 3f;

    public void PlayerDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
