using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacao : MonoBehaviour
{
    public movievyolence jogador;
    public Animator animator;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }
    void resetanimation()
    {
        animator.SetBool("escada", false);
        animator.SetBool("correndo", false);
        animator.SetBool("pulando", false);
        animator.SetBool("caindo", false);
    }
    // Update is called once per frame
    void Update()
    {
        resetanimation();
        
        if (this.jogador.naescada == true)
        {
            this.animator.SetBool("escada", true);
            animator.StopPlayback();
            if (Mathf.Abs(this.jogador.rb.velocity.y) != 0)
            {
                animator.Play("Vyolence_escada");
            }
        }
        else if (this.jogador.naescada == false)
        {
            this.animator.SetBool("escada", false);
        }
        

            
                float velocidadeX = Mathf.Abs(this.rb.velocity.x);
                if (velocidadeX > 0)
                {
                    this.animator.SetBool("correndo", true);
                }
                else
                {
                    this.animator.SetBool("correndo", false);
                }
            



        
        if (this.jogador.taNoChao)
        {
            this.animator.SetBool("pulando", false);
            this.animator.SetBool("caindo", false);

        }
        {
            float velocidadeY = this.rb.velocity.y;
            if ((velocidadeY > 0) && !(jogador.taNoChao))
            {
                this.animator.SetBool("pulando", true);
                this.animator.SetBool("caindo", false);
            }
            else if ((velocidadeY < 0) && !(jogador.taNoChao))
            {
                this.animator.SetBool("pulando", false);
                this.animator.SetBool("caindo", true);
            }
           


        }
    }
}   

    

