using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System;

public class Cofrinho : MonoBehaviour{
    
    public Jogador jogador;
    private double valor;
    public InputField inputMoney;
    public GameObject textTotalCofre;
    public GameObject PanelTemCerteza;
    public GameObject PanelTemCertezaCofre;
    public GameObject textMensagemErro;
    public AudioSource audioEffect;
    public AudioClip[] cofreAudioEffects;

    private void Start() {
        textTotalCofre.GetComponent<Text>().text = jogador.getSaldoCofre().ToString();
    }
    public void OpenPanelTemCerteza()
    {
        Debug.Log(jogador.nome);
        bool isActive = PanelTemCerteza.activeSelf;
        if (PanelTemCerteza != null)
        {
            PanelTemCerteza.SetActive(!isActive);

        }
        else
        {
            PanelTemCerteza.SetActive(isActive);

        }


    }

    public void OpenPanelTemCertezaCofre()
    {
        textTotalCofre.GetComponent<Text>().text = "R$" + jogador.getSaldoCofre().ToString();
        bool isActive = PanelTemCertezaCofre.activeSelf;
        if (PanelTemCertezaCofre != null)
        {
            PanelTemCertezaCofre.SetActive(!isActive);
        }
        else
        {
            PanelTemCertezaCofre.SetActive(isActive);

        }


    }
   
    public void addMoney()
    {
        bool isActive = PanelTemCerteza.activeSelf;

        try{
            if ((double.Parse(inputMoney.text)) <= 0)
            {
                Debug.Log("Entre com um valor maior que zero!");
                textMensagemErro.GetComponent<Text>().text = "Entre com um valor maior que zero!";
                PanelTemCerteza.SetActive(!isActive);
            }
            else if ((double.Parse(inputMoney.text)) > 0)
            {
                // jogador.addDinheiroCofre(valor);
                // valor += double.Parse(inputMoney.text);
                
                textTotalCofre.GetComponent<Text>().text = "R$" + jogador.addDinheiroCofre(double.Parse(inputMoney.text));
                textMensagemErro.GetComponent<Text>().text = "";
                audioEffect.clip = cofreAudioEffects[0];
                audioEffect.Play();

                if (PanelTemCerteza != null)
                {
                    PanelTemCerteza.SetActive(!isActive);
                    inputMoney.text = "";
                    textMensagemErro.GetComponent<Text>().text = "";
                }
                else
                {
                    PanelTemCerteza.SetActive(isActive);
                }

                
            }
        }
        catch (Exception e)
        {
            Debug.Log("Entre com um valor! "+e);
            textMensagemErro.GetComponent<Text>().text = "Entre com um valor!";
            PanelTemCerteza.SetActive(!isActive);
        }
    }

    public void quebrarCofre()
    {
        bool isActive = PanelTemCertezaCofre.activeSelf;

        try{
            if (jogador.saldoCofre <= 0)
            {
                Debug.Log("Antes de tentar quebrar o cofrinho, que tal colocar dinheiro dentro dele?");
                textMensagemErro.GetComponent<Text>().text = "Antes de tentar quebrar o cofrinho, que tal colocar dinheiro dentro dele?";
                PanelTemCertezaCofre.SetActive(!isActive);
            }
            else if (jogador.saldoCofre > 0)
            {
                jogador.quebraCofre();
                textTotalCofre.GetComponent<Text>().text = "R$" + jogador.saldoCofre.ToString();


                if (PanelTemCertezaCofre != null)
                {
                    jogador.quebraCofre();
                    PanelTemCertezaCofre.SetActive(!isActive);
                    inputMoney.text = "";

                    audioEffect.clip = cofreAudioEffects[1];
                    audioEffect.Play();

                }
                else
                {
                    PanelTemCertezaCofre.SetActive(isActive);

                }
            }

        }
        catch (Exception e)
        {
            Debug.Log("Que tal colocar dinheiro dentro do cofrinho primeiro?" + e);
            textMensagemErro.GetComponent<Text>().text = "Que tal colocar dinheiro dentro do cofrinho primeiro?";
            PanelTemCertezaCofre.SetActive(!isActive);
        }

        /*
        valor = 0;
        textTotalCofre.GetComponent<Text>().text = "R$" + valor.ToString();
        if (PanelTemCertezaCofre != null)
        {
            jogador.quebraCofre();
            PanelTemCertezaCofre.SetActive(!isActive);
            inputMoney.text = "";

             audioEffect.clip = cofreAudioEffects[1];
             audioEffect.Play();
             
        }
        else
        {
            PanelTemCertezaCofre.SetActive(isActive);

        }

        */

    }

}

// caso n de certo use -->   inputMoney.GetComponent<Text>().text