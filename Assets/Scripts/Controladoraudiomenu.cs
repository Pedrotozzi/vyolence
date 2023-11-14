using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controladoraudiomenu : MonoBehaviour
{
    private bool estadoSom = true;
    [SerializeField] private AudioSource fundoMusica;

    [SerializeField] private Sprite somLigadoSprite;
    [SerializeField] private Sprite somDesligadoSprite;

    [SerializeField] private Image muteImage;

    [SerializeField] private AudioSource somclick;

    public void LigarDesligarSom()
    {
        estadoSom = !estadoSom;
        fundoMusica.enabled = estadoSom;

        if (estadoSom)
        {
            muteImage.sprite = somLigadoSprite;
        }
        else
        {
            muteImage.sprite = somDesligadoSprite;
        }
    }

    public void VolumeMusical(float value)
    {
        fundoMusica.volume = value;
    }
    public void Clickaudio()
    {
        somclick.enabled = true;
    }
}
