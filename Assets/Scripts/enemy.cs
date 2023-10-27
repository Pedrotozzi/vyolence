using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    public bool ground = true;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool facingRight = true;
    public EdgeCollider2D visaoInimigo;
    private bool bateunaparede;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        ground = Physics2D.Linecast(groundCheck.position, transform.position, groundLayer);
        Debug.Log(ground);

        if (ground == false ||bateunaparede)
        {
            speed *= -1;
            bateunaparede = false;
        }

        if (speed > 0 && !facingRight)
        {
            Flip();
        }
        else if (speed < 0 && facingRight)
        {
            Flip();
        }

    }
    void Flip()
    {

        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&& !collision.gameObject.GetComponent<movievyolence>().taNaCaixa)
        {
            collision.gameObject.GetComponent<movievyolence>().setplayermorte(false);  
        }
        else if (collision.tag == "Player"&& collision.gameObject.GetComponent<movievyolence>().taNaCaixa)
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CapsuleCollider2D>(), GetComponent<CapsuleCollider2D>());
        }
        if (collision.tag == "parede") bateunaparede = true;
        



    }
}


