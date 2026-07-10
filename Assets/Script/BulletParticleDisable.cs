using UnityEngine;

public class BulletParticleDisable : MonoBehaviour
{
    private ParticleSystem ps;

    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (!ps.IsAlive())
        {
            gameObject.SetActive(false);
        }
    }
}
