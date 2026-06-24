using UnityEngine;

public class GameManager : MonoBehaviour
{
  void Awake()
  {
        DontDestroyOnLoad(gameObject);

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        Time.fixedDeltaTime = 0.0167f;
  }
}
