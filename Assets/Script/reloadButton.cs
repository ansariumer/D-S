using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class reloadButton : MonoBehaviour
{
    public BulletCounter bulletCounter;
    public bool isReloading = false;

    public Button reloadBtn;
    [SerializeField] private float reloadDuration = 1.5f;

    public void Reload()
    {
        if (bulletCounter.currentCount == bulletCounter.Fit)
        {
            return;
        }

        else if (bulletCounter.totalCount <= 0)
        {
            Debug.Log("No ammo left to reload");
            return;
        }

        isReloading = true;
        bulletCounter.reloadingText.SetActive(true);
        reloadBtn.interactable = false;
        StartCoroutine(Reloading());
    }

    private IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadDuration);

        bulletCounter.currentCount = bulletCounter.Fit;
        bulletCounter.totalCount -= bulletCounter.Fit;

        bulletCounter.RefreshUI();

        bulletCounter.reloadingText.SetActive(false);
        isReloading = false;
        reloadBtn.interactable = true;
    }
}
