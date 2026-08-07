using UnityEngine;
using System.Collections;

public class DacentaMovement : MonoBehaviour
{
    public Transform target;

    [Header("Movement")]
    public float rotationSpeed;
    public float speed = 7f;

    public bool isInsideDash;
    public bool isInside;

    [Header("Dash")]
    public float dashTime = 0.5f;
    public float dashSpeed = 20f;
    public float dashCooldown = 2f;

    private bool isDashing = false;
    private bool canDash = true;

    private Vector2 dashTarget;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isDashing)
        {
            if (isInside)
            {
                enemyRotation();
                enemyChase();
            }

            if (isInsideDash && canDash)
            {
                StartCoroutine(Dash());
            }
        }
    }

    private void enemyRotation()
    {
        Vector3 direction = target.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle - 90f);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime);
    }

    private void enemyChase()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime);
    }

    public IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        
        //Lock the players position
        dashTarget = target.position;

        Vector2 dashDirection = (dashTarget - (Vector2)transform.position).normalized;

        // Face the dash direction
        float angle = Mathf.Atan2(dashDirection.y, dashDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);

        float timer = 0f;

        while (timer < dashTime)
        {
            transform.position += (Vector3)(dashDirection * dashSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
        
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }
}

