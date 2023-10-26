using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movie2D : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed;
    private float direction;

    public Animator animator;

    private Vector3 facingRight;
    private Vector3 facingLeft;

    public bool taNoChao;
    public Transform detectaChao;
    public LayerMask oQueEhChao;


    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            //esta correndo
            animator.SetBool("taCorrendo", true);
        }
        else
        {
            //esta parado
            animator.SetBool("taCorrendo", false);
        }
         

        taNoChao = Physics2D.OverlapCircle(detectaChao.position, 0.2f, oQueEhChao);

        if (Input.GetButtonDown("Jump") && taNoChao == true)
        {
            rb.velocity = Vector2.up * 8; 
        }


        direction = Input.GetAxis("Horizontal");

        if(direction > 0)
        {
            //olhando para a direita
            transform.localScale = facingRight;
        }
        if (direction < 0)
        {
            //olhando para a esquerda
            transform.localScale = facingLeft;
        }


        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
            
    }
}
