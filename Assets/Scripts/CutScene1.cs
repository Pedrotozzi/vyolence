using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene1 : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }
}
