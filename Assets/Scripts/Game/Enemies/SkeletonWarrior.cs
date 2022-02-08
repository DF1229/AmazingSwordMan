using UnityEngine;
using System.Collections;

public class SkeletonWarrior : Enemy {
    private void OnEnable()
    {
        pointsWorth = 75;
        healthPoints = 250f;
        attackRange = 3f;
        attackDamage = 10;
        attackCooldown = 5f;
    }
}
