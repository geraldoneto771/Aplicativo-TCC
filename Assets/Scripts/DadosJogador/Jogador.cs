using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Jogador", menuName = "Aplicativo-TCC/Jogador", order = 0)]
public class Jogador : ScriptableObject {
    public string nome;
    public int bonus = 3;
    public int saude = 5;
    public int forca;
    public int agilidade;
    public int rapidez = 3;
    public float orcamento = 25.0f;
    public string personalidade;
    public string conhecimento;
    public int nivel; 
    private double saldoCofre = 0;
    public double tutorialTelaInicial = 0, tutorialEscolhaRotas = 0 , tutorialTelaFases = 0, tutorialTelaCofrinho = 0, tutorialTelaConversor = 0, tutorialTelaIntroducao = 0, tutorialTelaAventura = 0; // 0 - Não apareceu, 1 - Já apareceu;

    public bool usarOrcamento(float valor){
        bool liberaValor = valor <= this.orcamento;
        
        if(liberaValor){
            this.orcamento -= valor;
        }
        
        return liberaValor;
    }
    
    public bool usarBonus(int qtdBonus, string ATRIBUTO){
        // Avalia se a quantidade que deseja usar de bonus é maior do que se tem
        // caso positivo ele retorna falso

        if(qtdBonus > this.bonus){
            return false;
        }
        
        this.bonus -= qtdBonus;

        switch (ATRIBUTO){
            case "SAUDE":
                this.saude += qtdBonus;
                break;
            case "FORCA":
                this.forca += qtdBonus;
                break;
            case "AGILIDADE":
                this.agilidade += qtdBonus;
                break;
            case "RAPIDEZ":
                this.rapidez += qtdBonus;
                break;
            default:
                //throw new Exception("Valor não para variável ATRIBUTO errado: você escreveu "+ATRIBUTO);
                Debug.LogError($"Valor não para variável ATRIBUTO errado: você escreveu {ATRIBUTO}");
                return false;
        }

        return true;
    }

    public double addDinheiroCofre(double valor){
        if(valor >= 0){
            return this.saldoCofre += valor;
        }else{
            //throw new Exception("Impossivel adcionar valores negativos no cofrinho");
            Debug.LogError("Impossivel adcionar valores negativos no cofrinho");
            return this.saldoCofre;
        }
    }

    public double getSaldoCofre(){
        return this.saldoCofre;
    }

    public double quebraCofre(){
        this.saldoCofre = 0;
        return 0;
    }

    public void restaurarDados()
    {
        this.saldoCofre = 0;
        this.orcamento = 25.0f;
        this.bonus = 3;
        this.rapidez = 3;
        this.saude = 5;
        this.forca = 3;
        this.agilidade = 2;
        this.tutorialTelaAventura = 0;
        this.tutorialTelaCofrinho = 0;
        this.tutorialTelaConversor = 0;
        this.tutorialTelaFases = 0;
        this.tutorialTelaInicial = 0;
        this.tutorialTelaIntroducao = 0;
    }
}