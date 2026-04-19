using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject infos;
    public GameObject credits;
    public GameObject showCreditsButton;
    public GameObject showInfosButton;

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void ShowCredits()
    {
        if (credits.activeInHierarchy)
        {
            credits.SetActive(false);
            infos.SetActive(true);
            showInfosButton.SetActive(false);
            showCreditsButton.SetActive(true);
        }
        else
        {
            credits.SetActive(true);
            infos.SetActive(false);
            showInfosButton.SetActive(true);
            showCreditsButton.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}