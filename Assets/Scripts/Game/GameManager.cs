using UnityEngine.InputSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Set in unity editor
    public GameObject pauseMenu;

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
}
