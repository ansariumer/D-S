using UnityEngine;
using System.Collections;

public class DacentaMovement : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed;
    public bool isInside;
    public float speed = 7f;

    //Dash
    public bool isInsideDash;
    public float dashTime = 0.5f;
    public bool isDashing;
    private Vector2 dashVelocity;
    public float dashSpeed = 20f;


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
        /*else if (isInsideDash == true)
        {
            Dash();
        }*/
        else
        {
            return;
        }

        if (isInsideDash == true)
        {
            StartCoroutine(Dash());
        }
    }

    private void enemyRotation()
    {
        Vector3 direction = target.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle - 90f);

        transform.rotation = targetRotation;
    }

    private void enemyChase()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public IEnumerator Dash()
    {
        isDashing = true;
        Vector2 direction = (target.position - transform.position).normalized;
        dashVelocity = direction * dashSpeed;
        transform.position += (Vector3)(dashVelocity * Time.deltaTime);

        yield return new WaitForSeconds(dashTime);

        isDashing = false;
    }

}
