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
    // Start is called before the first frame update
    public void LoadScene(string name)
    {
        //Carregar cena de acordo com seu nome
       SceneLoader.Instance.LoadSceneAsync(name);
       SceneManager.LoadScene(name);
    }
}
