using UnityEngine;

public class BlastoKill : MonoBehaviour
{
    
    //public SpawnManager spawnManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if(player.isDashing == false)
            {
                //Blast();
                BlastoHealth blastoHealth = GetComponent<BlastoHealth>();
                Destroy(gameObject);
                blastoHealth.Play();

                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                playerHealth.PlayerDamage(10);
                Debug.Log("Blasto");
                //Debug.Log("Now Play");
            }
            else
            {
                /*GameObject hitEffect = BulletParPooling.instance.GetPoolObject();
                
                if (hitEffect != null)
                {
                    hitEffect.transform.position = gameObject.transform.position;
                    hitEffect.SetActive(true);
                }*/
                BlastoHealth enemy = GetComponent<BlastoHealth>();
                if (enemy != null)
                {
                    enemy.TakeDamage(3);
                }
                
            }
        }   
        else if (collision.gameObject.CompareTag("Dacenta"))
        {
            BlastoHealth enemy = GetComponent<BlastoHealth>();
            if (enemy != null)
            { 
                enemy.TakeDamage(3);
            }
        }     
        else if (collision.gameObject.CompareTag("Scholler"))
        {
            BlastoHealth enemy = GetComponent<BlastoHealth>();
            if (enemy != null)
            { 
                enemy.TakeDamage(3);
            }
        }
        else if (collision.gameObject.CompareTag("Blasto"))
        {
            BlastoHealth enemy = GetComponent<BlastoHealth>();
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
