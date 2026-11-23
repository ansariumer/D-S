using UnityEngine;
using System.Collections;

public class ItemDrop : MonoBehaviour
{
    public float popForce = 5f;
    public float horizontalForce = 1f;
    public float popDuration = 0.8f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            float randomX = Random.Range(-horizontalForce, horizontalForce);

            rb.AddForce(new Vector2(randomX, popForce), ForceMode2D.Impulse);
            StartCoroutine(StopMovement());
        }
    }

    IEnumerator StopMovement()
    {
        yield return new WaitForSeconds(popDuration);

        rb.linearVelocity = Vector2.zero; // make the movement on all aixs 0
        rb.angularVelocity = 0f; // make the roation 0
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
}
