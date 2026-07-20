using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public EnemyMovement enemyMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyMovement.isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyMovement.isInside = false;
        }
    }
}
