using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnchantressMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if(Horizontal < 0.0f) transform.localScale = new Vector3(-0.4f,0.4f,0.4f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(0.4f,0.4f,0.4f);

        Animator.SetBool("Running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down*0.14f, Color.red);

    
        Grounded  = Physics2D.Raycast(transform.position, Vector3.down, 0.14f);
        Animator.SetBool("Grounded", Grounded);

        if(Input.GetKeyDown(KeyCode.Space) && Grounded){
            Animator.SetBool("Jumping", true);
            Jump();
        }else{
            Animator.SetBool("Jumping", false);
        }
    }

    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate() {
        Rigidbody2D.linearVelocity = new Vector2(Horizontal, Rigidbody2D.linearVelocity.y);

    }
}
