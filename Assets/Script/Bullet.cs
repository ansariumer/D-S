using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    void Update()
   {
        transform.position += transform.up * speed * Time.deltaTime;
   } 
}
