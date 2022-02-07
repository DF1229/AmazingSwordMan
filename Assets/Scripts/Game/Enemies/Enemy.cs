using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Seeker))]
[RequireComponent(typeof(AIPath))]
[RequireComponent(typeof(AIDestinationSetter))]
public class Enemy : MonoBehaviour
{
    public AIPath aiPath;
    public Player player;
    public Room currRoom;
    public LayerMask playerLayer;
    public Vector3 defaultPosition;


    public int pointsWorth;
    public float healthPoints;
    public float attackRange;
    public float attackDamage;
    public float attackCooldown;
    [SerializeField] protected float attackAnimDelay;

    private Animator animator;

    private void Awake()
    {
        aiPath = this.GetComponent<AIPath>();
        animator = this.GetComponent<Animator>();
    }

    // Called first, handles physics
    private void FixedUpdate()
    {
        // Calculate distance to target, and attack if in range
        float dtt = Vector3.Distance(player.transform.position, this.transform.position);
        if (dtt <= attackRange && attackCooldown <= 0f)
        {
            animator.SetTrigger("Attack");
            Invoke(nameof(Attack), attackAnimDelay);
        }

        if (aiPath.desiredVelocity != Vector3.zero)
            animator.SetInteger("AnimState", 1);
        else
            animator.SetInteger("AnimState", 0);

        attackCooldown -= Time.fixedDeltaTime;
    }

    private void Attack()
    {
        Vector2 origin = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 direction = this.player.transform.position - this.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, attackRange, playerLayer);

        if (!hit)
            return;

        Player player = hit.transform.GetComponent<Player>();
        if (player)
            player.TakeDamage(attackDamage);

        attackCooldown = 2f;
    }

    public void TakeDamage(float dmg)
    {
        this.healthPoints -= dmg;
        if (healthPoints <= 0f)
        {
            animator.SetTrigger("Death");
            player.AddScore(pointsWorth);

            Reset();

            //List<Enemy> activeEnemies = currRoom.GetActiveEnemies();
            //if (activeEnemies.Count == 0)
            if (!GameManager.Instance.ActiveEnemies())
                currRoom.nextWave();
        } else if (healthPoints >= 1)
        {
            animator.SetTrigger("Hurt");
        }

    }

    public void Reset()
    {
        healthPoints = 100;
        attackCooldown = 2f;
        this.transform.localPosition = defaultPosition;
        this.gameObject.SetActive(false);
    }
}
