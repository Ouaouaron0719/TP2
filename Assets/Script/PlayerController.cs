using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f; 
    [SerializeField] private Rigidbody2D rb; 
    private Animator animator; 

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        
        float move = Input.GetAxis("Horizontal");

        
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        
        animator.SetFloat("Speed", Mathf.Abs(move));

        
        if (move != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(move) * Mathf.Abs(scale.x); 
            transform.localScale = scale;
        }

        
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            Physics2D.gravity = new Vector2(0, Physics2D.gravity.y * -1);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
             
        }
    }

}
