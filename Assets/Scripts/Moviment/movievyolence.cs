using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movievyolence : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed;
    private float horizontaldirection;
    private float verticaldirection;
    private Vector3 facingRight;
    private Vector3 facingLeft;

    public bool taNoChao;
    public Transform detectaChao;
    public LayerMask oQueEhChao;
    public bool naescada;
    public float velocidadeescada;

     
    private bool playerControling = true;

    private Animator animator;

    // Start is called before the first frame update
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


            taNoChao = Physics2D.OverlapCircle(detectaChao.position, 0.2f, oQueEhChao);

        if (!naescada && Input.GetButtonDown("Jump") && taNoChao == true)
        {
            rb.velocity = Vector2.up * 8;
        }



        if (playerControling)
        {
            horizontaldirection = Input.GetAxis("Horizontal");
            if (naescada == true)
            {
                verticaldirection = Input.GetAxis("Vertical");
            }
            if (horizontaldirection > 0)
            {
                //olhando para a direita
                transform.localScale = facingRight;
            }
            if (horizontaldirection < 0)
            {
                //olhando para a esquerda
                transform.localScale = facingLeft;
            }


            Vector2 velocity;
            if (!naescada) velocity = new Vector2(horizontaldirection * moveSpeed, rb.velocity.y);
            else velocity = new Vector2(horizontaldirection * moveSpeed, verticaldirection * velocidadeescada);
            rb.velocity = velocity;
        }



    }
    public void setplayermorte(bool set)
    {
        playerControling = set;
        animator.SetTrigger("morte");
    }
    public void setplayerrun(bool set)
    {
        playerControling = set;
        animator.SetTrigger("correndo");

    }
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "escada")
        {
            naescada = true;
            rb.gravityScale = 0;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "escada")
        {
            naescada = false;
            rb.gravityScale = 1;

        }
    }
}
     

