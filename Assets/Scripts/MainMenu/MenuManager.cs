using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject howToMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (GameManager.Instance != null)
        {
            GameManager.Instance.Reset();
        }
    }

    public void ToggleHowToMenu()
    {
        if (howToMenu.activeSelf)
        {
            mainMenu.SetActive(true);
            howToMenu.SetActive(false);
        } else
        {
            howToMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
