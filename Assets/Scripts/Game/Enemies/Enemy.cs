using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Seeker))]
[RequireComponent(typeof(AIPath))]
[RequireComponent(typeof(AIDestinationSetter))]
public class Enemy : MonoBehaviour
{
    public LayerMask playerLayer;
    public Player target;
    [Range(1,5)]
    public float attackRange = 2;

    public AIPath aiPath;

    private void Awake()
    {
        aiPath = this.GetComponent<AIPath>();
    }

    private void FixedUpdate()
    {
        // Calculate distance to target, and attack if in range
        float dtt = Vector3.Distance(target.transform.position, this.transform.position);
        if (dtt < attackRange)
            Attack();

        // Monitor direction of travel, and flip sprite as needed
        if (aiPath.desiredVelocity.x >= 0.01f)
            this.transform.localScale = new Vector3(-1f, 1f, 1f);
        else
            this.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void Attack()
    {
        Vector2 origin = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 direction = new Vector2(Vector3.forward.x, Vector3.forward.y);
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, attackRange, playerLayer);
    }
}
