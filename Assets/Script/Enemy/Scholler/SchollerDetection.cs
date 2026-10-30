using UnityEngine;

public class SchollerDetection : MonoBehaviour
{
    public SchollerMovement schollerMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            schollerMovement.isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            schollerMovement.isInside = false;
        }
    }
}
