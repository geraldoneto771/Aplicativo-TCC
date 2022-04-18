using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class ChangeImageScenes : MonoBehaviour
{

    
    public AudioClip lofi;
    public AudioClip introducao;
    //Vetor de imagens contendo as cenas da aventura
    public Image cenasDoJogo;
    public Sprite[] sprites;

    int index;

    void Start()
    {
        
        //index = 0;
        //spriteRender = GetComponent<SpriteRenderer>();
        //spriteRender.sprite = sprites[0];


        //Renderizando os sprites no vetor
        sprites = Resources.LoadAll("Cenas Introdução", typeof(Sprite)).Cast<Sprite>().ToArray();
        index = 0;
        cenasDoJogo = this.GetComponent<Image>();
        cenasDoJogo.sprite = sprites[index];
        AudioController.instance.PlayMusic(introducao);
    }

    public void NextChangeImage()
    {
        index++;

        cenasDoJogo.sprite = sprites[index];

    }
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
