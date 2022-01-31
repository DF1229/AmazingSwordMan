using UnityEngine.InputSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerControls playerControls;
    public Movement movement { get; private set; }

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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TransferDirection(InputAction.CallbackContext ctx)
    {
        movement.SetDirection(ctx.ReadValue<Vector2>());
    }
}
