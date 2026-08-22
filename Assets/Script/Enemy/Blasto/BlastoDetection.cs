using UnityEngine;

public class BlastoDetection : MonoBehaviour
{
    public BlastoMovement blastoMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            blastoMovement.isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            blastoMovement.isInside = false;
        }
    }
}
