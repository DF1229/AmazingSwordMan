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

    private void Awake()
    {
        aiPath = this.GetComponent<AIPath>();
    }

    private void FixedUpdate()
    {
        

        // Calculate distance to target, and attack if in range
        float dtt = Vector3.Distance(player.transform.position, this.transform.position);
        if (dtt <= attackRange && attackCooldown <= 0f)
            Attack();

        attackCooldown -= Time.fixedDeltaTime;

        // Monitor direction of travel, and flip sprite as needed
        if (aiPath.desiredVelocity.x >= 0.01f)
            this.transform.localScale = new Vector3(1f, 1f, 1f);
        else
            this.transform.localScale = new Vector3(-1f, 1f, 1f);
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
            player.AddScore(pointsWorth);

            Reset();

            List<Enemy> activeEnemies = currRoom.GetActiveEnemies();
            if (activeEnemies.Count == 0)
                currRoom.nextWave();
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
