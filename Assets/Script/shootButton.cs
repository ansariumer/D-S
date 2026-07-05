using UnityEngine;

public class shootButton : MonoBehaviour
{
    public GameObject bullet;
    //public Button shootbtn;
    public Transform firePoint;
    public float firerate = 0.2f;
    //[SerializeField] private float speed;
    //private Rigidbody2D rb;

    float nextShootTime;

    public void Shoot()
    {
        if (Time.time >= nextShootTime)
        {
            nextShootTime = Time.time + firerate;
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}
