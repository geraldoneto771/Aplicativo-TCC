using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using TMPro;
public class NavigationSimple : MonoBehaviour
{
    //musicas
    public AudioClip lofi;
    

    // Start is called before the first frame update
    public void LoadScene(string name)
    {
        //Carregar cena de acordo com seu nome
        SceneLoader.Instance.ApagarTexto();
        SceneLoader.Instance.LoadSceneAsync(name);

        if(name == "Tela_Modulo_1" || name == "Tela_Inicial" || name == "Tela_Conversor" || name == "Tela_Cofre")
        {
            
            AudioController.instance.PlayMusic(lofi);
        }
       //SceneManager.LoadScene(name);
    }
}
