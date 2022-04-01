using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// CONfiguração inicial ao abrir a tela do cofre

public class MainCofre : MonoBehaviour{
    public GameObject textTotalCofre;
    public Jogador jogador;
    public Button voltarBTN;

    // Start is called before the first frame update
    void Start(){
        // textTotalCofre.GetComponent<Text>().text = "R$" + jogador.getSaldoCofre.ToString();
        //textoSaldo.text = "R$" + jogador.getSaldoCofre().ToString();
        // textTotalCofre.GetComponent<Text>().text = jogador.getSaldoCofre().ToString();
        Debug.Log(textTotalCofre.GetComponent<Text>().text);
        Debug.Log(jogador.getSaldoCofre().ToString());

        voltarBTN.onClick = new Button.ButtonClickedEvent();
        voltarBTN.onClick.AddListener(()=>SceneManager.LoadScene("Tela_Inicial"));
    }
}
