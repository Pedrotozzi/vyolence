using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;


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
    public bool naescada = false;
    public float velocidadeescada;
    public bool taNaCaixa = false;
    public bool podeEntrarNaCaixa;
    public bool podePegarBB;
    private SpriteRenderer spriterd;
    private CapsuleCollider2D colider;
    private Caixa caixaatual;
    public Porta portaatual;
    [SerializeField] private string nomeDoLevelDeJogo;

    public bool podeAbrirAPorta;
    public float gravidadeinicial;
    public bool podeEntrarNaEscada;
    public Transform attackPoint;
    public float attackRange = 0.2f;
    public LayerMask enemyLayers;
    public int danoDoAttack = 1;
    public bool podeatacar;
    public float cooldown;
    float lastAttack;
    private Fimjogo telaFimJogo;
    private AudioSource soundFx;
    

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
        spriterd = GetComponent<SpriteRenderer>();
        colider = GetComponent<CapsuleCollider2D>();
        caixaatual = null;
        gravidadeinicial = rb.gravityScale;
        GameObject fimJogogameobject = GameObject.FindGameObjectWithTag("TelaFimJogo");
        this.telaFimJogo = fimJogogameobject.GetComponent<Fimjogo>();
        this.telaFimJogo.Esconder();
        soundFx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && (!taNaCaixa))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.E) && podeEntrarNaCaixa && PodeMover())
        {
            rb.velocity = Vector2.zero;
            AlternarEntradaNaCaixa();
            spriterd.enabled = !taNaCaixa;
            caixaatual.tanacaixa = taNaCaixa;
        }
        else if (Input.GetKeyDown(KeyCode.E) && podeAbrirAPorta && PodeMover())
        {
            portaatual.taAberta = !portaatual.taAberta;

            if (portaatual.taAberta)
            {
                portaatual.PortaAberta();
            }
            else
            {
                portaatual.PortaFechada();
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && podeEntrarNaEscada && PodeMover())
        {
            entrarnaescada();
        }
        

        taNoChao = Physics2D.OverlapCircle(detectaChao.position, 0.2f, oQueEhChao);

        if (!naescada && Input.GetButtonDown("Jump") && taNoChao == true && PodeMover())
        {
            rb.velocity = Vector2.up * 8;
        }



        if (playerControling && PodeMover())
        {
            if (!taNaCaixa)
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
    }
    public void setplayermorte(bool set)
    {
        playerControling = set;
        animator.SetTrigger("morte");
        
        telaFimJogo.Exibir();
    }
    public void setplayerrun(bool set)
    {
        playerControling = set;
        animator.SetTrigger("correndo");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("escada"))
        {
            podeEntrarNaEscada = true;
            return;
        }
        if (collision.gameObject.CompareTag("caixa"))
        {
            podeEntrarNaCaixa = true;
            caixaatual = collision.gameObject.GetComponent<Caixa>();
            return;
        }
        else if (collision.gameObject.CompareTag("caixafinal"))
        {
            SceneManager.LoadScene(nomeDoLevelDeJogo);
        }
        if (collision.gameObject.CompareTag("porta"))
        {
            podeAbrirAPorta = true;
            portaatual = collision.gameObject.GetComponent<Porta>();
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "escada")
        {
            podeEntrarNaEscada = false;
            sairdaescada();
        }
        if (collision.gameObject.CompareTag("caixa"))
        {
            podeEntrarNaCaixa = false;
            caixaatual = null;

        }
        if (collision.gameObject.CompareTag("porta"))
        {
            podeAbrirAPorta = false;
            portaatual = null;

        }
        if (collision.gameObject.CompareTag("porta"))
        {
            podePegarBB = false;
        }

    }



    private void entrarnaescada()
    {
        rb.gravityScale = 0;
        naescada = true;
    }
    private void sairdaescada()
    {
        rb.gravityScale = gravidadeinicial;
        naescada = false;
    }

    public void AlternarEntradaNaCaixa()
    {
        taNaCaixa = !taNaCaixa;
    }
    public void PodeEntrarNaCaixa()
    {
        podeEntrarNaCaixa = true;
    }
    public void NaoPodeEntrarNaCaixa()
    {
        podeEntrarNaCaixa = false;
    }
    void Attack()
    {

        if (Time.time-lastAttack<cooldown)
        {
            return;
        }
        lastAttack = Time.time;
        animator.SetTrigger("atacar");
        soundFx.Play ();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemy>().TomarDano(danoDoAttack);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public bool PodeMover()
    {
        if (Time.time - lastAttack>0.6)
        {
           return true;
        }
        else
        {
            return false;
        }
    }

}  


