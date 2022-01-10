using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeImageScenes : MonoBehaviour
{

    public Sprite[] sprites;
    SpriteRenderer spriteRender;
   

    int index;

    void Start()
    {
        index = 0;
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.sprite = sprites[0];
    }

    public void NextChangeImage()
    {
        index++;
        
        spriteRender.sprite = sprites[index];

    }
    public void LoadScene(string name)
    {
        if (index >= 26)
        {
            //Carregar cena de acordo com seu nome
            SceneManager.LoadScene(name);
        }

        
    }
}
