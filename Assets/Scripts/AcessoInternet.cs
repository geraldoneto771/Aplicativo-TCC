using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AcessoInternet : MonoBehaviour
{

    public Text _txtResultado;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            _txtResultado.text = "Sem conex�o com a Internet!";
        }
        else
        {
            _txtResultado.text = "Conex�o com a Internet OK!";
        }
    }
}
