using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public CircleCollider2D feet;
    public float speed = 100f;
    public float jumpHeight = 100f;
    public bool frozen = false;
    private float mHorizontal;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feet = GetComponent<CircleCollider2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    
    void Update()
    {
        if(frozen){
            mHorizontal = 0;
            return;
        }
        mHorizontal = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && feet.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            rb.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }
    }

    public void FixedUpdate(){
        rb.velocity = new Vector2(mHorizontal * speed * Time.deltaTime, rb.velocity.y);
    }
}
