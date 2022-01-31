using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject howToMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ToggleHowToMenu()
    {
        if (howToMenu.activeSelf)
            howToMenu.SetActive(true);
        else
            howToMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
