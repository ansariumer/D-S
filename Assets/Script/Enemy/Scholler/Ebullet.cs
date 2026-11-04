using UnityEngine;

public class Ebullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Blast();
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.PlayerDamage(1);
            Debug.Log("Scholler Bullet");
        }
    } 

    public void Blast()
    {
        GameObject hitEffect = BulletParPooling.instance.GetPoolObject();

            if (hitEffect != null)
            {
                hitEffect.transform.position = gameObject.transform.position;
                hitEffect.SetActive(true);
            }
        Destroy(gameObject);
    }
}
