using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fimjogo : MonoBehaviour
{
    public Transform FimDeJogoMenu;
    [SerializeField] private string nomeDoLevelDeJogo;

    public void Exibir()
    {
       this.gameObject.SetActive(true);
       Time.timeScale = 0;
    }

    public void Esconder()
    {
        this.gameObject.SetActive(false);
    }

    public void TentarNovamente()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
        Time.timeScale = 1;
    }
    
}
