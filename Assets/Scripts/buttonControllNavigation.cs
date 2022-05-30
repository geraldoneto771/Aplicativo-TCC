using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonControllNavigation : MonoBehaviour{
    public void LoadScene(string name){
        //Carregar cena de acordo com seu nome
        SceneLoader.Instance.AdicionarTexto();
        SceneLoader.Instance.LoadSceneAsync(name);
    }

    public void Sair()
    {
        Application.Quit();
    }
}