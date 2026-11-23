using UnityEngine;

public class Player : MonoBehaviour
{
    public JoystickController joystickMove;
    public BulletCounter bulletCounter;

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

    public CameraZoom cameraZoom;

    public ParticleSystem dashParticle; // Particle
    public PlayerHealth playerHealth; // Health CS

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
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
        //Shap change
        if (isDashing)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, smoothspeed * Time.deltaTime);
            rb.linearVelocity = dashVelocity;
            return;
        }

        rb.linearVelocity = moveInput * speed;
    }

    public void Dash()
    { 
        isDashing = true;
        dashVelocity = moveInput * dash;

        trail.time = dashTime;
        trail.emitting = true;

        Play();
        
        Invoke(nameof(StopDash), dashTime);
    }
    
    public void StopDash()
    {
        isDashing = false;

        trail.emitting = false;
        trail.time = FadeOutTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Player hit");
        if (collision.gameObject.CompareTag("Blasto"))
        {
           if (!isDashing)
           {
                return;
           }
           else
           {
                BlastoHealth enemy = collision.gameObject.GetComponent<BlastoHealth>();
                enemy.TakeDamage(3);
                //Debug.Log("Hit!");
           }
        }

        if (collision.gameObject.CompareTag("Dacenta"))
        {
            if(!isDashing)
            {
                return;
            }
            else
            {
                DacentaHealth enemy = collision.gameObject.GetComponent<DacentaHealth>();
                enemy.TakeDamage(3);
            }
        }

        if (collision.gameObject.CompareTag("Scholler"))
        {
            if(!isDashing)
            {
                return;
            }
            else
            {
                SchollerHealth enemy = collision.gameObject.GetComponent<SchollerHealth>();
                enemy.TakeDamage(1.5f);
            }
        }
        
        if (collision.gameObject.CompareTag("HealthPoint"))
        {
            Debug.Log("Collected HealthPoint!!");
            playerHealth.HealthIncrease();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("R"))
        {/*
            if (bulletCounter.currentCount == bulletCounter.Fit)
            {
                return;
            }

            else
            Debug.Log("Refill");
            bulletCounter.totalCount = bulletCounter.Fit;
            bulletCounter.currentCount = bulletCounter.Fit;*/
            if (other.CompareTag("R"))
            {
                bulletCounter.totalCount = bulletCounter.Fit;
                bulletCounter.currentCount = bulletCounter.Fit;

                bulletCounter.RefreshUI();

                Debug.Log("Ammo Refilled");
            }

        }
    }

    void Play()
    {
        Debug.Log("Dash Particle!!");
        ParticleSystem particle = Instantiate(dashParticle, transform.position, Quaternion.identity);

        particle.Play();
        
        Destroy(particle.gameObject, particle.main.duration + particle.main.startLifetime.constantMax);
        //The newly particle is distroyed after its duration
    }
}