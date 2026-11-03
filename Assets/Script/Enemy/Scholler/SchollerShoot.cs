using UnityEngine;

public class SchollerShoot : MonoBehaviour
{
    public GameObject ebullet;
    public Transform firePoint;

    public float fireRate = 0.5f;
    private float nextTimeFire;

    public void Shoot()
    {
        if (Time.time >= nextTimeFire)
        {
            nextTimeFire = Time.time + fireRate;

            Instantiate(ebullet, firePoint.position, firePoint.rotation);
        }
    }
}
