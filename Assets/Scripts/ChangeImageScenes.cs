using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using TMPro;


public class ChangeImageScenes : MonoBehaviour
{

    public AudioClip lofi;
    public AudioClip introducao;
    //Vetor de imagens contendo as cenas da aventura
    public Image cenasDoJogo;
    public Sprite[] sprites;
    int index;
    public TMP_Text textCenas;
    private float porcentagemCenas;


    void Start()
    {
        //Renderizando os sprites no vetor
        sprites = Resources.LoadAll("Cenas Introdução", typeof(Sprite)).Cast<Sprite>().ToArray();
        index = 0;
        cenasDoJogo = this.GetComponent<Image>();
        cenasDoJogo.sprite = sprites[index];
        porcentagemCenas = 100f/26f;
        textCenas.GetComponent<TMP_Text>().text = string.Format("{0:0.00}", porcentagemCenas) + "%";
        AudioController.instance.PlayMusic(introducao);

    }

    //Função para prosseguir para cena posterior
    public void NextChangeImage()
    {
        index++;
        porcentagemCenas = porcentagemCenas + (100f/26f);
        
        textCenas.GetComponent<TMP_Text>().text = string.Format("{0:0.00}", porcentagemCenas) + "%";
        cenasDoJogo.sprite = sprites[index];

    }
    //Função para retornar para cena anterior
    public void PreviousChangeImage()
    {
       if(index >= 1)
        {
            index--;
            porcentagemCenas = porcentagemCenas - (100f / 26f);
            textCenas.GetComponent<TMP_Text>().text = string.Format("{0:0.00}", porcentagemCenas) + "%";
            cenasDoJogo.sprite = sprites[index];
        }

    }
    //Função para retornar para a tela de seleção de aventuras
    public void LoadScene(string name)
    {
        if (index >= 26)
        {
            //Carregar cena de acordo com seu nome
            SceneLoader.Instance.LoadSceneAsync(name);
            AudioController.instance.PlayMusic(lofi);
        }
     
    }
   
}
