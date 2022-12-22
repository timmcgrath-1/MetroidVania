using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private  Animator myAnimator;

    private bool facingRight = true;

    public float speed = 2.0f;
    public float horizMovement;
    // Start is called before the first frame update
    private void Start()
    {
        //define the game objects found on the player
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // handles the input for physics
    private void Update()
    {
        //check if player has input movement
        horizMovement = Input.GetAxisRaw("Horizontal");
        Debug.Log(horizMovement);
    }

    //handles running the physics
    private void FixedUpdate() {
        //move the player
        rb2D.velocity = new Vector2(horizMovement*speed,rb2D.velocity.y);
        Flip(horizMovement);
        myAnimator.SetFloat("speed", Mathf.Abs(horizMovement));
    }
// flipping function
    private void Flip(float horizontal) {
        if(horizontal<0 && facingRight || horizontal >0 && !facingRight) {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}

// flipping function