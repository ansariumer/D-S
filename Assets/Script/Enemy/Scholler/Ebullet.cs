using UnityEngine;

public class Ebullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Scholler Bullet");
        }
    } 
}
