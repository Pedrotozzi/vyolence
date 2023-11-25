using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public Sprite portaNormal;
    public Sprite portaAberta;
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private SpriteRenderer spritefront;
    public bool taAberta;
    private BoxCollider2D colider;
    public GameObject portafrente;
    private AudioSource soundfx;
    public Color cor;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        colider = GetComponent<BoxCollider2D>();
        portafrente.SetActive(false);
        soundfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame

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
        spritefront.color = cor;
        soundfx.Play();
    }



}
