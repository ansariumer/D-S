using UnityEngine;

public class Bullet : MonoBehaviour
{
     public GameObject bullet;
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
          Debug.Log("Bullet");
          bullet.SetActive(false);
     }
   }
}
