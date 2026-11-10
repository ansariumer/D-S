using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ComboBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    private float time = 4f;
    private Coroutine fillCoroutine;

    void Awake()
    {
        slider.maxValue = time;
        slider.value = time;
    }

    public void ComboStart()
    {
        if (fillCoroutine != null)
        {
            StopCoroutine(fillCoroutine);
        }
        
        fillCoroutine = StartCoroutine(FillReducer());
    }

    public void ResetFill()
    {
    
        if (fillCoroutine != null)
        {
            StopCoroutine(fillCoroutine);
            fillCoroutine = null;
        }

        time = 4f;
        slider.value = time;
    }

    IEnumerator FillReducer()
    {
        time = 4f; 
        
        while(time > 0)
        {
            time -= Time.deltaTime;
            slider.value = time;
            yield return null;
        }
        fillCoroutine = null;
        Debug.Log("Disappera");
    }
}
