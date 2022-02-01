using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Set in unity editor
    public GameObject pauseMenu;
    public GameObject howToMenu;
    public GameObject deathMenu;
    public GameObject quitMenu;

    // Set in script
    public bool paused = false;

    // GameManager singleton
    private static GameManager _instance;
    public static GameManager Instance {get { return _instance; }}

    void Awake()
    {
        _instance = this;
    }

    public void TogglePause(InputAction.CallbackContext ctx = new InputAction.CallbackContext())
    {
       if (paused)
        {
            paused = false;
            Time.timeScale = 1f;
            TogglePauseMenu();
        } else
        {
            paused = true;
            Time.timeScale = 0f;
            TogglePauseMenu();
        }
    }

    // <menus>
    private void TogglePauseMenu()
    {
        if (paused)
            pauseMenu.SetActive(false); 
        else
            pauseMenu.SetActive(true);
    }

    public void ToggleHowToMenu()
    {
        if (howToMenu.activeSelf)
        {
            howToMenu.SetActive(false);
            pauseMenu.SetActive(true);
        } else
        {
            pauseMenu.SetActive(false);
            howToMenu.SetActive(true);
        }
    }

    public void ToggleQuitMenu()
    {
        if (quitMenu.activeSelf)
        {
            quitMenu.SetActive(false);
            pauseMenu.SetActive(true);
        } else if (!quitMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            quitMenu.SetActive(true);
        } 
        if (deathMenu.activeSelf)
        {
            deathMenu.SetActive(false);
            pauseMenu.SetActive(true);
        } else if (!deathMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            deathMenu.SetActive(true);
        }
    }

    public void ShowDeathMenu()
    {
        TogglePause();
        if (!deathMenu.activeSelf)
            deathMenu.SetActive(true);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Resources.UnloadUnusedAssets();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    // </menus>
}
