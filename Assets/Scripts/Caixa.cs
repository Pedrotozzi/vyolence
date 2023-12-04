using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixa : MonoBehaviour
{
    //private BoxCollider2D 
    public Sprite caixaNormal;
    public Sprite caixaCheia;
    private SpriteRenderer spriteRender;
    public bool tanacaixa;
    private AudioSource saundfx;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        CaixaNormal();
        saundfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {      
        if (tanacaixa)
        {
            CaixaCheia();
            
        }
        else
        {
            CaixaNormal();
        }
    }

    public void CaixaNormal()
    {
        spriteRender.sprite = caixaNormal;
        
    }
    public void SomCaixa()
    {
        saundfx.Play();
    }
    public void CaixaCheia()
    {  
        spriteRender.sprite = caixaCheia;
    }
    
    


}

