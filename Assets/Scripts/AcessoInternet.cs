using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AcessoInternet : MonoBehaviour{

    public Text _txtResultado;

    // Update is called once per frame
    void Update(){
        if(Application.internetReachability == NetworkReachability.NotReachable){
            _txtResultado.text = "Sem conexão com a Internet!";
        }else{
            _txtResultado.text = "Conexão com a Internet OK!";
        }
    }
}
