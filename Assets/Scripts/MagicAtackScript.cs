using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAtackScript : MonoBehaviour
{
    public float Speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
    private Vector3 Orientation;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.localScale = Orientation;
        Rigidbody2D.linearVelocity = Direction * Speed;
    }

    public void SetDirection(Boolean direction){
        if(direction){
            Direction = Vector3.right;
            Orientation = new Vector3(0.4f,0.4f,0.4f);
        }else{
           Direction = Vector3.left; 
           Orientation = new Vector3(-0.4f,0.4f,0.4f);
        }
        
    }

    public void DestroyAtack(){
        Destroy(gameObject);
    }
}
