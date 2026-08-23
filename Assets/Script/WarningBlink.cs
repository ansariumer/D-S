using UnityEngine;
using TMPro;

public class FlickerText : MonoBehaviour
{
    private TMP_Text text;
    public GameObject dacenta;

    [SerializeField] private float minInterval = 0.02f;
    [SerializeField] private float maxInterval = 0.12f;

    private float timer;
    private bool visible = true;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        dacenta = GameObject.FindGameObjectWithTag("Dacenta");
        visible = false;
        text.alpha = 0f;
    }

    private void Update()
    {
        if (dacenta != null)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                // Randomly change visibility
                visible = Random.value > 0.25f;

                text.alpha = visible ? 1f : 0f;

                // Random time until the next flicker
                timer = Random.Range(minInterval, maxInterval);
            }
        }
        else
        {
            return;
        }
    }
}
