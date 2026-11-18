using UnityEngine;

public class SchollerKill : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if(player.isDashing == false)
            {
               // Blast();
                SchollerHealth schollerHealth = GetComponent<SchollerHealth>();
                schollerHealth.Play();
                Destroy(gameObject);
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                playerHealth.PlayerDamage(30);
                Debug.Log("Scholler");
            }
            else
            {
                GameObject hitEffect = BulletParPooling.instance.GetPoolObject();
                
                if (hitEffect != null)
                {
                    hitEffect.transform.position = gameObject.transform.position;
                    hitEffect.SetActive(true);
                }
                /*BlastoHealth enemy = GetComponent<BlastoHealth>();
                if (enemy != null)
                {
                    enemy.TakeDamage(3);
                }*/
                
            }
        }    
        else if (collision.gameObject.CompareTag("Blasto"))
        {
            SchollerHealth enemy = GetComponent<SchollerHealth>();
            if (enemy != null)
            { 
                enemy.TakeDamage(3);
            }
        }     
        else if (collision.gameObject.CompareTag("Dacenta"))
        {
            SchollerHealth enemy = GetComponent<SchollerHealth>();
            if (enemy != null)
            { 
                enemy.TakeDamage(3);
            }
        }
        else if (collision.gameObject.CompareTag("Scholler"))
        {
            SchollerHealth enemy = GetComponent<SchollerHealth>();
            if (enemy != null)
            { 
                enemy.TakeDamage(3);
            }
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
