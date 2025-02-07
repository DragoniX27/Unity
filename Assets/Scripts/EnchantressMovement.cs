using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnchantressMovement : MonoBehaviour
{
    public GameObject MagicAtackPrefab;
    public float Speed;
    public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private int AtackPhase = 0;

    private bool Atacking;
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

        if(Input.GetKeyDown(KeyCode.K)){
            if(Grounded && !Atacking){
                Atacking = true;
                if(AtackPhase < 2){
                    AtackPhase = AtackPhase+1;
                }
                Atack();
            }else{
                AtackPhase = 0;
            }
        }
        Animator.SetInteger("Atacking", AtackPhase);
    }

    private void Atack(){

        GameObject atack = Instantiate(MagicAtackPrefab, transform.position + ((transform.localScale.x == 0.4f)? Vector3.right : Vector3.left) * 0.1f, Quaternion.identity);
        atack.GetComponent<MagicAtackScript>().SetDirection(transform.localScale.x == 0.4f);
    }

    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    public void DisAtack(){
        Atacking = false;
    }

    private void FixedUpdate() {
        Rigidbody2D.linearVelocity = new Vector2(Horizontal, Rigidbody2D.linearVelocity.y);
    }
}
