using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene1 : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    SpriteRenderer spriterender;
    CanvasRenderer canvas;
    public CanvasRenderer botao;

   

    void Start()
    {
        StartCoroutine(rotina());
        spriterender = GetComponent<SpriteRenderer>();

    }

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo); 
    }

    IEnumerator rotina()
    {
        yield return new WaitForSeconds(15);
        canvas = botao;
        botao.gameObject.SetActive(true);
    }
}
