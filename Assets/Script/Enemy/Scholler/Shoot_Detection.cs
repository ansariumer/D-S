using UnityEngine;

public class Shoot_Detection : MonoBehaviour
{
    public SchollerMovement schollerMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            schollerMovement.isInsideShoot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            schollerMovement.isInsideShoot = false;
        }
    }
}
