using UnityEngine;

public class BlastoMovement : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed;
    public bool isInside = false; 
    public float speed = 5f;

    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    
    void Update()
    {
        if (isInside == true)
        {
            enemyRotation();
            enemyChase();
        }
        else
        {
            return;
        }
    }

    private void enemyRotation()
    {
        Vector3 direction = target.position - transform.position;

        // Convert radians to degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Create the target rotation
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle - 90f);

        // Apply the rotation
        transform.rotation = targetRotation;
    } 

    private void enemyChase()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                                                // currentPosition, targetPosition, speed;
    }
}