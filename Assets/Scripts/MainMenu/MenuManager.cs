using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject howToMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ToggleHowToMenu()
    {
        if (howToMenu.activeSelf)
        {
            mainMenu.SetActive(false);
            howToMenu.SetActive(true);
        } else
        {
            howToMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
