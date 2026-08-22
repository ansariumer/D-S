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
                Blast();
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                playerHealth.PlayerDamage(2); 
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
