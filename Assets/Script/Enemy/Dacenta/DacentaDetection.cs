using UnityEngine;

public class DacentaDetection : MonoBehaviour
{
    public DacentaMovement dacentaMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dacentaMovement.isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dacentaMovement.isInside = false;
        }
    }

}
