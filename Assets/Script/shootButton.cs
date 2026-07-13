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
        if (reloadBtn.isReloading)
        {
            return;
        }

        if (bulletCounter.CanShoot() == false)
        {
            return;
        }

        else if(Time.time >= nextShootTime)
        {
            nextShootTime = Time.time + firerate;
            //Instantiate(bullet, firePoint.position, firePoint.rotation);
            GameObject bullet = bulletPooling.instance.GetPoolObject();
            bulletCounter.SubtractBullet();

            if (bullet != null)
            {
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.rotation;
                bullet.SetActive(true);
            }
        }
    }
}
