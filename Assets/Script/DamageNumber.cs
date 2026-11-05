using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public float speed = 50f;
    public float lifeTime = 1f;
    public TextMeshProUGUI textMesh;
    private float time;

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        time += Time.deltaTime;

        if(time < lifeTime)
        {
            float alpha = 1f - (time / lifeTime); // fades calculation
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, alpha);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDamage(int damageAmount)
    {
        if(textMesh != null)
        {
            textMesh.text = "-" + damageAmount.ToString();
        }
    }
}
