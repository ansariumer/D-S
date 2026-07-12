using UnityEngine;
using TMPro;

public class BulletCounter : MonoBehaviour
{
    public TMP_Text totalText;
    public TMP_Text slashText;
    public TMP_Text currentText; 
    
    public int totalCount = 200;
    public int currentCount = 20;
    public int Fit = 20;

    public reloadButton reloadBtn;

    public void SubtractBullet()
    {
        currentCount--;
        RefreshUI();

        
        if (currentCount == 0 && totalCount != 0)
        {
            reloadBtn.Reload();
        }
    }

    public void RefreshUI()
    {
        currentText.text = currentCount.ToString();
        totalText.text = totalCount.ToString();

        if (totalCount == 0)
        {
            totalText.color = Color.red;
        }
        else
        {
            totalText.color = Color.white;
        }

        if (currentCount == 0 && totalCount == 0)
        {
            currentText.color = Color.red;
            slashText.color = Color.red;
        }
    }
}
