using UnityEngine;

public class shootButton : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float firerate = 0.2f;

    float nextShootTime;

    public void Shoot()
    {
        Debug.Log("Shoot");
        if (Time.time >= nextShootTime)
        {
            nextShootTime = Time.time + firerate;
            //Instantiate(bullet, firePoint.position, firePoint.rotation);
            GameObject bullet = bulletPooling.instance.GetPoolObject();
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;

            if (bullet != null)
            {
                bullet.transform.position = firePoint.position;
                bullet.transform.position = firePoint.position;
                bullet.SetActive(true);
            }
        }
    }
}
