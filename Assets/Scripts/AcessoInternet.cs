using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AcessoInternet : MonoBehaviour{

    public Text _txtResultado;
  

    // Update is called once per frame
    void Update(){
        if(Application.internetReachability == NetworkReachability.NotReachable){

            _txtResultado.color = new Color32(209, 60, 67, 255);
            _txtResultado.text = "Sem conexão com a Internet!";
            
        }
        else{

            _txtResultado.color = new Color32(6, 122, 255, 255);
            _txtResultado.text = "Conexão com a Internet OK!";
            
        }
    }
}
