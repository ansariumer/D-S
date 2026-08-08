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

    //Taril
    private TrailRenderer trail;
    [SerializeField] private float FadeOutTime = 0.2f;

    //Scale
    private Vector3 originalScale;
    private Vector3 targetScale = new Vector2(0.7f, 1f); 
    [SerializeField] private float changeSpeed = 5f; 

    //Warning
    [SerializeField] private float dashWarningTime = 0.8f;
    [SerializeField] private GameObject dashWarning;

    private bool isWarning = false;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        originalScale = transform.localScale;

        trail = GetComponentInChildren<TrailRenderer>();
        trail.emitting = false;

        dashWarning.SetActive(false);

    }

    void Update()
    {
        if (!isDashing)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, changeSpeed * Time.deltaTime);

            if (isInside)
            {
                enemyRotation();
                enemyChase();
            }

            if (isInsideDash && canDash && !isWarning)
            {
                StartCoroutine(DashWarning());
            }
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, changeSpeed * Time.deltaTime);
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

        trail.time = dashTime;
        trail.emitting = true;
        
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
        
        trail.emitting = false;
        trail.time = FadeOutTime;

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }

    private IEnumerator DashWarning()
    {
        isWarning = true;

        dashWarning.SetActive(true);

        yield return new WaitForSeconds(dashWarningTime); 

        dashWarning.SetActive(false);
        
        StartCoroutine(Dash());

        isWarning = false;
    }
}

