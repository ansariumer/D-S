using UnityEngine;
using TMPro;

public class BulletCounter : MonoBehaviour
{
    public TMP_Text currentText; 
    public TMP_Text totalText;

    public int currentCount = 20;
    public int totalCount = 200;
    public int Fit = 20;

    //int totalUpdate = totalCount - Fit;
    public void SubtractBullet()
    {
        currentCount--;
        currentText.text = " " + currentCount.ToString();
    }
}
