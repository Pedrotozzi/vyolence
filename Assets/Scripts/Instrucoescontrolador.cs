using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instrucoescontrolador : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
        Time.timeScale = 1;
    }

}
