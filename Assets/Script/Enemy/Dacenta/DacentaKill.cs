using UnityEngine;

public class DacentaKill : MonoBehaviour
{
    //public BlastoDeath blastoDeath;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if(player.isDashing == false)
            {
                //Blast();
                DacentaHealth dacentaHealth = GetComponent<DacentaHealth>();
                Destroy(gameObject);
                dacentaHealth.Play();
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                playerHealth.PlayerDamage(20); 
            }
            else
            {
                GameObject hitEffect = BulletParPooling.instance.GetPoolObject();
                
                if (hitEffect != null)
                {
                    hitEffect.transform.position = gameObject.transform.position;
                    hitEffect.SetActive(true);
                }
                DacentaHealth enemy = GetComponent<DacentaHealth>();
                if (enemy != null)
                {
                    enemy.TakeDamage(3);
                }   
            }
        }
        else if (collision.gameObject.CompareTag("Blasto"))
        {
            DacentaHealth enemy = GetComponent<DacentaHealth>();
            if (enemy != null)
            { 
                enemy.TakeDamage(3);
            }
        }     
        else if (collision.gameObject.CompareTag("Scholler"))
        {
            DacentaHealth enemy = GetComponent<DacentaHealth>();
            if (enemy != null)
            { 
                enemy.TakeDamage(3);
            }
        }
        else if (collision.gameObject.CompareTag("Dacenta"))
        {
            DacentaHealth enemy = GetComponent<DacentaHealth>();
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
