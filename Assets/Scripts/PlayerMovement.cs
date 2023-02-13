using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sr;

    Vector2 movement;

    /// <summary>
    /// Metoda, ktera se vola kazdy frame a zkouma hracuv input, pocita vektor kam hrac chce jit a meni parametry animatoru, aby se prehravala spravna animace.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        // Input

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        sr.flipX = movement.x < 0.01 ? true : false;
    }

    /// <summary>
    /// Na fyziku je ve hrach potreba vyuzivat metody FixedUpdate(), ktere frekvence volani nezalezi na framerateu.
    /// Tahle metoda slouzi na posouvani hrace vyslednym vektorem ziskanym v inputu, ktery nasobi rychlosti pohybu a fixovanym casovym intervalem, kterym
    /// je vykonavana i metoda FixedUpdate().
    /// </summary>
    void FixedUpdate()
    {
        // Movement

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
