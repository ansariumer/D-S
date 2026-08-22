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
   }
}
