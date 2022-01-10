using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AventuraSolo : MonoBehaviour
{
    // Futuramente a meta é ter mais de um módulo
    public int idMódulo;

    // Variaveis
    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text infoRespostas;


    // Banco de dados
    public string[] perguntas;      // armazena todas as perguntas
    public string[] alternativaA;   // armazena todas as alternativas A
    public string[] alternativaB;   // armazena todas as alternativas B
   // armazena todas as alternativas D
    public string[] corretas;       // armazena as alternativas corretas.

    // Outras váriaveis
    private int idPergunta;
    private float acertos;
    private float questoes;
    private float media;


    // Start is called before the first frame update
    void Start()
    {
        /*idPergunta = 0;
        questoes = perguntas.Length;

        // iniciando perguntas
        pergunta.text = perguntas[idPergunta];

        // Iniciando respostas
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];


        // INFO RESPOSTAS
        infoRespostas.text = "QUIZ " + (idPergunta + 1).ToString() + "/5";*/
    }

    //RESPOSTAS
    public void respostaAventura(string alternativa)
    {

        if (alternativa == "A")
        {
            if (alternativaA[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }
        else if (alternativa == "B")
        {
            if (alternativaB[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }

        proximaPerguntaAventura();
    }

    // alterando pergunta
    void proximaPerguntaAventura()
    {

        idPergunta += 1;

        if (idPergunta <= (questoes - 1))
        {
            // iniciando perguntas
            pergunta.text = perguntas[idPergunta];

            // Iniciando respostas
            respostaA.text = alternativaA[idPergunta];
            respostaB.text = alternativaB[idPergunta];

            // INFO RESPOSTAS
            infoRespostas.text = "QUIZ " + (idPergunta + 1).ToString() + "/5";
        }
        else
        {
            //o que fazer se terminar as perguntas
            SceneManager.LoadScene("Tela_Inicial");
        }



    }



}