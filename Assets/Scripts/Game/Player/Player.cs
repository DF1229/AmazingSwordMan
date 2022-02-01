using UnityEngine.InputSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerControls playerControls;
    public Movement movement { get; private set; }

    public HealthBar healthBar;
    public float healthPoints = 100;
    public float attackRange = 4;
    public float attackDamage = 25;

    private void Awake()
    {
        playerControls = new PlayerControls();
        movement = this.GetComponent<Movement>();
    }

    private void OnEnable()
    {
        playerControls.Base.Enable();
    }

    private void OnDisable()
    {
        playerControls.Base.Move.performed -= TransferDirection;
        playerControls.Base.Move.canceled -= TransferDirection;
        playerControls.Base.Pause.performed -= GameManager.Instance.TogglePause;

        playerControls.Base.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerControls.Base.Move.performed += TransferDirection;
        playerControls.Base.Move.canceled += TransferDirection;

        playerControls.Base.Pause.performed += GameManager.Instance.TogglePause;
    }

    private void TransferDirection(InputAction.CallbackContext ctx)
    {
        movement.SetDirection(ctx.ReadValue<Vector2>());
    }

    public void TakeDamage(float dmg)
    {
        this.healthPoints -= dmg;
        healthBar.SetHealth(healthPoints);

        if (healthPoints <= 0f)
        {
            GameManager.Instance.TogglePause();
            GameManager.Instance.ShowDeathMenu();
        }
    }
}
