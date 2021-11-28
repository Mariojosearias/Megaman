using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    public int Radius;

    void Update()
    {
        Collider2D Hitting = Physics2D.OverlapCircle(transform.position, Radius, LayerMask.GetMask("Player"));

        if (Hitting != null)
        aiPath.enabled = true;
        else
        aiPath.enabled = false;

        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}

