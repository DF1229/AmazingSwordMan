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
    public Player player;

    // Set in script
    [HideInInspector] public bool paused = false;
    [HideInInspector] public bool dead = false;

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

    public void TogglePause()
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

    public void Reset()
    {
        paused = false;
        Time.timeScale = 1f;
        player.Reset();
    }

    public bool ActiveEnemies()
    {
        Enemy enemy = (Enemy) FindObjectOfType(typeof(Enemy));
        if (enemy)
            return true;
        else
            return false;
    }

    // <menus>
    private void TogglePauseMenu()
    {
        if (paused)
        {
            pauseMenu.SetActive(true);
        }
        else
            pauseMenu.SetActive(false);
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
        if (dead)
        {
            if (deathMenu.activeSelf)
                deathMenu.SetActive(false);
            else
                deathMenu.SetActive(true);
        } else
        {
            if (pauseMenu.activeSelf)
                pauseMenu.SetActive(false);
            else
                pauseMenu.SetActive(true);
        }

        if (quitMenu.activeSelf)
            quitMenu.SetActive(false);
        else
            quitMenu.SetActive(true);
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
