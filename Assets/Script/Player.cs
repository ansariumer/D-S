/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public JoystickController joystickMove;
    public DashController dashController;
    public float speed = 10f;
    public float dash = 20f;
    public float dashTime = 0.5f;
    public bool isDashing;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isDashing = false;
    }

    void Update()
    {
        if (isDashing == false)
        {
            Movement();
        }
    }

    public void Movement()
    {
        rb.linearVelocity = joystickMove.Direction * speed;
        
        if (rb.linearVelocity != Vector2.zero)
        {
            transform.up = rb.linearVelocity;
        }
        isDashing = false;
    }

    public void Dash(Vector2 dir)
    {
        if (dir == Vector2.zero) return;

        StartCoroutine(DashDuration());
        isDashing = true;
        transform.up = dir;
        rb.linearVelocity = dir * dash;
    }

    private IEnumerator DashDuration()
    {
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
    }
}*/
using UnityEngine;

public class Player : MonoBehaviour
{
    public JoystickController joystickMove;
    public DashController dashController;

    public float speed = 10f;
    public float dash = 20f;
    public float dashTime = 0.5f;

    public bool isDashing;
    public Rigidbody2D rb;

    private Vector2 moveInput;
    private Vector2 dashVelocity;

    private Vector3 originalScale;
    private Vector3 targetScale = new Vector2(0.7f, 1f);
    [SerializeField] private float smoothspeed = 5f;

    private TrailRenderer trail;
    [SerializeField] private float FadeOutTime = 0.2f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;

        trail = GetComponentInChildren<TrailRenderer>();
    }

    void Update()
    {
        if (!isDashing)
        {
            trail.time = FadeOutTime;
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, smoothspeed * Time.deltaTime);
            moveInput = joystickMove.Direction;

            if (moveInput != Vector2.zero)
                transform.up = moveInput; // visual only (safe in Update)
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, smoothspeed * Time.deltaTime);
            trail.time = dashTime;
            rb.linearVelocity = dashVelocity;
            return;
        }

        rb.linearVelocity = moveInput * speed;
    }

    public void Dash(Vector2 dir)
    {
        if (dir == Vector2.zero) return;

        isDashing = true;
        dashVelocity = dir * dash;
        transform.up = dir;

        Invoke(nameof(StopDash), dashTime);
    }

    void StopDash()
    {
        isDashing = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
           if (!isDashing)
           {
                return;
           }
           else
           {
                Enemy enemy = other.GetComponent<Enemy>();
                enemy.TakeDamage(1);
                Debug.Log("Hit!");
           }
        }
    }
}