using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed;
    public bool isInside = false; 

    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    
    void Update()
    {
        if (isInside == true)
        {
            enemyRotation();
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
}