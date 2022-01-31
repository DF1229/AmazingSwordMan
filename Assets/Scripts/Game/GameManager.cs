using UnityEngine.InputSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Set in unity editor
    public GameObject pauseMenu;
    public GameObject howToMenu;
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

    public void TogglePause(InputAction.CallbackContext ctx)
    {
        if (paused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            paused = false;
        } else {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            paused = true;
        }
    }

    public void TogglePause()
    {
        if (paused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            paused = false;
        } else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            paused = true;
        }
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
        } else
        {
            pauseMenu.SetActive(false);
            quitMenu.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
