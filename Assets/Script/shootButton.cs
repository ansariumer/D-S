using UnityEngine;

public class shootButton : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float firerate = 0.2f;

    public BulletCounter bulletCounter;
    public reloadButton reloadBtn;

    float nextShootTime;

    public void Shoot()
    {
        if (reloadBtn.isReloading == true)
        {
            return;
        }

        else if (bulletCounter.currentCount == 0 && bulletCounter.totalCount == 0)
        {
            //bulletCounter.currentText.color = Color.red;
            Debug.Log("Out of Ammo");
            return;
        }

        else if(Time.time >= nextShootTime)
        {
            nextShootTime = Time.time + firerate;
            //Instantiate(bullet, firePoint.position, firePoint.rotation);
            GameObject bullet = bulletPooling.instance.GetPoolObject();
            FindAnyObjectByType<BulletCounter>().SubtractBullet();

            if (bullet != null)
            {
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.rotation;
                bullet.SetActive(true);
            }
        }
    }
}
