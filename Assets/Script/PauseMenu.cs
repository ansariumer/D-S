using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject resumeGame;

    void Start()
    {
        //pauseMenu.SetActive(false);
    }

    public void OpenPauseMenu() // Open Menu
    {
        pauseMenu.SetActive(true);
    }

    public void ClosePauseMenu() // Close Menu
    {
        pauseMenu.SetActive(false);
    }

    public void RestartGame(string sceneName) // Restart
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
