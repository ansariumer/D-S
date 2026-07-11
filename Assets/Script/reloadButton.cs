using UnityEngine;

public class reloadButton : MonoBehaviour
{
    public BulletCounter bulletCounter;

    public void Reload()
    {
        bulletCounter.currentCount = 20;
        bulletCounter.totalCount -= bulletCounter.Fit; 

        int totalUpdate = bulletCounter.totalCount - bulletCounter.Fit;

        bulletCounter.currentText.text = bulletCounter.currentCount.ToString();
        bulletCounter.totalText.text = totalUpdate.ToString();
    }
}
