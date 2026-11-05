using UnityEngine;
using UnityEngine.UI;

public class ShakeHealthBar : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 originalAnchoredPos;

    private float shakeMagnitude;
    private float shakeDuration;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        originalAnchoredPos = rectTransform.anchoredPosition;
    }

    public void shakeHealth()
    {
        shakeMagnitude = 30f;
        shakeDuration = 5f;
    }
    void Update()
    {
        if (shakeDuration > 0)
        {
            float offsetX = Random.Range(-shakeMagnitude, shakeMagnitude);
            float offsetY = Random.Range(-shakeMagnitude, shakeMagnitude);
            rectTransform.anchoredPosition = originalAnchoredPos + new Vector2(offsetX, offsetY);

            shakeDuration -= Time.deltaTime;
            shakeMagnitude *= 0.95f; 
        }
        else
        {
            shakeMagnitude = 0;
            rectTransform.anchoredPosition = originalAnchoredPos;
        }
    }   
}