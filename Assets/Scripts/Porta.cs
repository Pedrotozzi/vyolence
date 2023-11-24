using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public Sprite portaNormal;
    public Sprite portaAberta;
    private SpriteRenderer spriteRender;
    public bool taAberta;
    private BoxCollider2D colider;
    public GameObject portafrente;
    private AudioSource soundfx;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        colider = GetComponent<BoxCollider2D>();
        portafrente.SetActive (false);
        soundfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (taAberta)
        {
            
            PortaAberta();
            Audioporta();
        }
        else
        {
            PortaFechada();

        }
    }
    public void PortaFechada()
    {
        spriteRender.sprite = portaNormal;
        colider.enabled = true;
        portafrente.SetActive(false);
    }
    public void PortaAberta()
    {
        spriteRender.sprite = portaAberta;
        colider.enabled = false;
        portafrente.SetActive(true);
    }
    public void Audioporta()
    {
        soundfx.Play();
    }



}
