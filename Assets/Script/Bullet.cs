using UnityEngine;

public class Bullet : MonoBehaviour
{
     public GameObject bullet;
     public ParticleSystem bulletParticle;
     [SerializeField] private float speed = 10f;
     [SerializeField] private Rigidbody2D rb;

     void FixedUpdate()
     {
          rb.linearVelocity = transform.up * speed;
     } 

     private void OnTriggerEnter2D(Collider2D other)
     {
          if (other.CompareTag("Finish"))
          {
               gameObject.SetActive(false);

                GameObject hitEffect = BulletParPooling.instance.GetPoolObject();

               if (hitEffect != null)
               {
                    hitEffect.transform.position = bullet.transform.position;
                    hitEffect.SetActive(true);
               }
          }

          else if (other.CompareTag("Blasto"))
          {
               BlastoHealth enemy = other.GetComponent<BlastoHealth>();
               enemy.TakeDamage(1);
               bullet.SetActive(false);
               //Instantiate(bulletParticle, transform.position, Quaternion.identity);
               GameObject hitEffect = BulletParPooling.instance.GetPoolObject();

               if (hitEffect != null)
               {
                    hitEffect.transform.position = bullet.transform.position;
                    hitEffect.SetActive(true);
               }
               
          }
          else if (other.CompareTag("Dacenta"))
          {
               DacentaHealth enemy = other.GetComponent<DacentaHealth>();
               enemy.TakeDamage(1);
               bullet.SetActive(false);
               //Instantiate(bulletParticle, transform.position, Quaternion.identity);
               GameObject hitEffect = BulletParPooling.instance.GetPoolObject();

               if (hitEffect != null)
               {
                    hitEffect.transform.position = bullet.transform.position;
                    hitEffect.SetActive(true);
               }
               
          }
          else if (other.CompareTag("Scholler"))
          {
               SchollerHealth enemy = other.GetComponent<SchollerHealth>();
               enemy.TakeDamage(1);
               bullet.SetActive(false);
               //Instantiate(bulletParticle, transform.position, Quaternion.identity);
               GameObject hitEffect = BulletParPooling.instance.GetPoolObject();

               if (hitEffect != null)
               {
                    hitEffect.transform.position = bullet.transform.position;
                    hitEffect.SetActive(true);
               }
               
          }
   }
}
