using UnityEngine;

public class Bullet : MonoBehaviour
{
     public GameObject bullet;
     public ParticleSystem bulletParticle;
     [SerializeField] private float speed = 10f;

     void Update()
     {
          transform.position += transform.up * speed * Time.deltaTime;
     } 

     private void OnTriggerEnter2D(Collider2D other)
     {
          if (other.CompareTag("Finish"))
          {
               gameObject.SetActive(false);
          }

          else if (other.CompareTag("Enemy"))
          {
               Enemy enemy = other.GetComponent<Enemy>();
               enemy.TakeDamage(1);
               Debug.Log("Bullet hit");
               Instantiate(bulletParticle, transform.position, Quaternion.identity);
               bullet.SetActive(false);
          }
   }
}
