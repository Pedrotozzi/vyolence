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

    // Update is called once per frame
    void Update()
    {
        {

            {
                float velocidadeX = Mathf.Abs(this.rb.velocity.x);
                if (velocidadeX > 0)
                {
                    this.animator.SetBool("correndo", true);
                }
                else
                {
                    this.animator.SetBool("correndo", false);
                }
            }





        }
        if (this.jogador.taNoChao)
        {
            this.animator.SetBool("pulando", false);
            this.animator.SetBool("caindo", false);

        }
        else
        {
            float velocidadeY = this.rb.velocity.y;
            if (velocidadeY > 0)
            {
                this.animator.SetBool("pulando", true);
                this.animator.SetBool("caindo", false);
            }
            else if (velocidadeY < 0)
            {
                this.animator.SetBool("pulando", false);
                this.animator.SetBool("caindo", true);
            }

        }
    }
}   

    

