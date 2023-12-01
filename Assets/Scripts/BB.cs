using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BB : MonoBehaviour
{
    public Sprite caixaNormal;
    public Sprite caixaCheia;
    private SpriteRenderer spriteRender;
    public bool tanacaixa;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        CaixaNormal();
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
    public void CaixaCheia()
    {
        spriteRender.sprite = caixaCheia;
    }
}
