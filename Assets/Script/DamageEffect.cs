using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageEffect : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    
    public void Blink()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ColorChange(0.1f, 3));
    }

    IEnumerator ColorChange(float interval, int times)
    {
        for(int i = 0; i < times; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(interval);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(interval);
        }
    }

    
}
