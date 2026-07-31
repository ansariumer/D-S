using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject GameOverPanel;
    public Button restartBtn;

    void Awake()
    {
        GameOverPanel.SetActive(false);
        restartBtn.interactable = false;
    }

    public void GameOverP()
    {   
        GameOverPanel.SetActive(true);
        restartBtn.interactable = true;

        Time.timeScale = 0f; //Game Pause
    }

    public void Restart(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}
