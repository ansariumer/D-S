using UnityEngine;

public class S_DashDetection : MonoBehaviour
{
    public SchollerMovement schollerMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            schollerMovement.isInsideDash = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            schollerMovement.isInsideDash = false;
        }
    }
}
