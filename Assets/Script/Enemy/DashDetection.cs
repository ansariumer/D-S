using UnityEngine;

public class DashDetection : MonoBehaviour
{
    public DacentaMovement dacentaMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Dash area entered");
            dacentaMovement.isInsideDash = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dacentaMovement.isInsideDash = false;
        }
    }
}
