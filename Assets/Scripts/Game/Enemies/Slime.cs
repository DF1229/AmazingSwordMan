using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    private void OnEnable()
    {
        pointsWorth = 5;
        healthPoints = 50f;
        attackRange = 1f;
        attackDamage = 2.5f;
        attackCooldown = 1f;
    }
}
