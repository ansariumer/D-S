using UnityEngine;
using TMPro;

public class BulletCounter : MonoBehaviour
{
    public TMP_Text currentText;

    private int currentCount = 20;

    public void SubtractBullet()
    {
        currentCount--;
        currentText.text = " " + currentCount.ToString();
    }
}
