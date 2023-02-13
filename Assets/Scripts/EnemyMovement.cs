using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    public AIPath aiPath;
    public Animator animator;
    public SpriteRenderer sr;

    /// <summary>
    /// Metoda Update(), se aktualizuje kazdy frame a v tomto skriptu ma funkci takovou, ze prenastavuje parametry animatoru, podle smeru pohybu. Dusledkem toho je prehravani spravnych animaci pohybu.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", aiPath.desiredVelocity.x);
        animator.SetFloat("Vertical", aiPath.desiredVelocity.y);
        animator.SetFloat("Speed", aiPath.desiredVelocity.sqrMagnitude);

        sr.flipX = aiPath.desiredVelocity.x < 0.01 ? true : false;
    }
}
