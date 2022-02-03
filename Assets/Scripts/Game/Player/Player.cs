using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private PlayerControls playerControls;
    public Movement movement { get; private set; }

    public HealthBar healthBar;
    public TextMeshProUGUI scoreText;
    [HideInInspector] public int score = 0;

    public LayerMask enemyLayer;
    public float healthPoints = 100f;
    public float attackRange = 4f;
    public float attackDamage = 25f;
    public float attackCooldown = 2f;

    public Room currRoom;

    private void Awake()
    {
        playerControls = new PlayerControls();
        movement = this.GetComponent<Movement>();
    }

    private void OnDestroy()
    {
        playerControls.Base.Move.performed -= TransferDirection;
        playerControls.Base.Move.canceled -= TransferDirection;
        playerControls.Base.Attack.performed -= Attack;
        playerControls.Base.Pause.performed -= GameManager.Instance.TogglePause;
        playerControls.Base.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerControls.Base.Enable();
        playerControls.Base.Move.performed += TransferDirection;
        playerControls.Base.Move.canceled += TransferDirection;
        playerControls.Base.Attack.performed += Attack;
        playerControls.Base.Pause.performed += GameManager.Instance.TogglePause;
    }

    private void FixedUpdate()
    {
        attackCooldown -= Time.fixedDeltaTime;
    }

    private void TransferDirection(InputAction.CallbackContext ctx)
    {
        movement.SetDirection(ctx.ReadValue<Vector2>());
    }

    private Enemy FindClosestEnemy(List<Enemy> enemies)
    {
        Enemy eClosest = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = this.transform.position;

        foreach (Enemy e in enemies)
        {
            float dist = Vector3.Distance(e.transform.position, currentPos);
            if (dist < minDist)
            {
                eClosest = e;
                minDist = dist;
            }
        }

        return eClosest;
    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        if (!currRoom.hasEnemies || currRoom.finished || attackCooldown > 0f)
            return;

        List<Enemy> enemies = currRoom.GetActiveEnemies();
        Enemy target = null;

        if (enemies != null)
            target = FindClosestEnemy(enemies);

        if (!target)
            return;

        float dtt = Vector3.Distance(target.transform.position, this.transform.position);
        if (dtt <= attackRange)
        {
            attackCooldown = 2f;

            Vector2 origin = new Vector2(this.transform.position.x, this.transform.position.y);
            Vector2 direction = target.transform.position - this.transform.position;
            RaycastHit2D hit = Physics2D.Raycast(origin, direction, attackRange, enemyLayer);
            Debug.DrawRay(transform.position, direction, Color.green, 2.0f);

            if (!hit)
                return;

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy)
                enemy.TakeDamage(this, attackDamage);
        }
    }

    public void TakeDamage(float dmg)
    {
        this.healthPoints -= dmg;
        healthBar.SetHealth(healthPoints);

        if (healthPoints <= 0f)
            GameManager.Instance.ShowDeathMenu();
    }

    public void AddScore(int input)
    {
        score += input;
        scoreText.text = score.ToString();
    }
}
