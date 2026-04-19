using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gamePausedPanel;
    
    public bool isPaused;

    public void OpenGameOverPanel()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        gamePausedPanel.SetActive(false);
    }
    
    public void OpenGamePausedPanel()
    {
        if (isPaused)
        {
            Unpause();
            return;
        }
        Time.timeScale = 0;
        isPaused = true;
        gameOverPanel.SetActive(false);
        gamePausedPanel.SetActive(true);
    }
    
    public void TryAgain()
    {
        Debug.Log("TryAgain");
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void BackToMenu()
    {
        Debug.Log("BackToMenu");
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Unpause()
    {
        gamePausedPanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}