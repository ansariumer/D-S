using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Blast();
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            player.PlayerDamage(1);
            Debug.Log("Cluster 💥");
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
