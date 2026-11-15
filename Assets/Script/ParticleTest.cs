using UnityEngine;

public class ParticleTest : MonoBehaviour
{
    public ParticleSystem dieEffect;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            dieEffect.Play();
        }
    }
}
