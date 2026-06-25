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
        trail.emitting = false;
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

        trail.time = dashTime;
        trail.emitting = true;

        Invoke(nameof(StopDash), dashTime);
    }

    void StopDash()
    {
        isDashing = false;

        trail.emitting = false;
        trail.time = FadeOutTime;
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