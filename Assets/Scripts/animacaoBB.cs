using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacaoBB : MonoBehaviour
{
    public movievyolenceBB jogador;
    public Animator animator;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }
    void resetanimation()
    {
        animator.SetBool("escadaBB", false);
        animator.SetBool("correndoBB", false);
        animator.SetBool("pulandoBB", false);
        animator.SetBool("caindoBB", false);
    }
    // Update is called once per frame
    void Update()
    {
        resetanimation();
        
        if (this.jogador.naescada == true)
        {
            this.animator.SetBool("escadaBB", true);
            if ((this.jogador.rb.velocity.y > 0) || (this.jogador.rb.velocity.y < 0))
            {
                this.animator.SetBool("paradaescadaBB", false);
            }
            else if (this.jogador.rb.velocity.y == 0)
            {
                this.animator.SetBool("paradaescadaBB", true);
            }
        }
        else if (this.jogador.naescada == false)
        {
            this.animator.SetBool("paradaescadaBB", false);
            this.animator.SetBool("escadaBB", false);
        }
        

            
                float velocidadeX = Mathf.Abs(this.rb.velocity.x);
                if (velocidadeX > 0)
                {
                    this.animator.SetBool("correndoBB", true);
                }
                else
                {
                    this.animator.SetBool("correndoBB", false);
                }
            



        
        if (this.jogador.taNoChao)
        {
            this.animator.SetBool("pulandoBB", false);
            this.animator.SetBool("caindoBB", false);

        }
        {
            float velocidadeY = this.rb.velocity.y;
            if ((velocidadeY > 0) && !(jogador.taNoChao) && !(jogador.naescada)) 
            {
                this.animator.SetBool("pulandoBB", true);
                this.animator.SetBool("caindoBB", false);
            }
            else if ((velocidadeY < 0) && !(jogador.taNoChao))
            {
                this.animator.SetBool("pulandoBB", false);
                this.animator.SetBool("caindoBB", true);
            }
           


        }
    }
}   

    

