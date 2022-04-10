using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationSimple : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene(string name)
    {
        //Carregar cena de acordo com seu nome
        SceneManager.LoadScene(name);
    }
}
