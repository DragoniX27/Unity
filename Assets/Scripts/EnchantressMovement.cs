using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnchantressMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private bool Grounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        Debug.DrawRay(transform.position, Vector3.down*0.14f, Color.red);

        if(Physics2D.Raycast(transform.position, Vector3.down, 0.14f)){
            Grounded  = true;
        }else{
            Grounded = false;
        }
        if(Input.GetKeyDown(KeyCode.Space) && Grounded){
            Jump();
        }
    }

    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate() {
        Rigidbody2D.linearVelocity = new Vector2(Horizontal, Rigidbody2D.linearVelocity.y);

    }
}
