using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Linq;

public class AventuraSoloControle : MonoBehaviour
{
    // Dados do personagem
    public Jogador jogador;
    //Vetor de imagens contendo as cenas da aventura
    public Image cenasDoJogo;
    public Sprite[] sprites;
    //SpriteRenderer spriteRender;
    //Verificador de rota
    int verificadorDeRota;
    int rotas;
    //Verificador da posição do vetor de sprites
    int index;
    //botoões
    public RectTransform bttNext, bttOption01, bttOption02, bttOption03;
    //textos
    public GameObject textOrcamento, textSaude, textForca, textAgilidade, textRapidez, textBonus;

    public GameObject PanelErro;
    public GameObject textErro;
    public GameObject bttOk;
    //Pontuação
    //int forca = 3, agilidade = 2, rapidez = 3, saude = 5, pontoBonus = 3;

    //float orcamento = 25;


    //Verificador de grupo de botões
    int bttIndex;

    // Start is called before the first frame update
    void Start()
    {
        
        atualizarDadosNoMenuDeAtributos();
        
        //Renderizando os sprites no vetor
        sprites = Resources.LoadAll("Cenas Decisão 01 - Inicio", typeof(Sprite)).Cast<Sprite>().ToArray();
        //spriteRender = GetComponent<SpriteRenderer>();
        //spriteRender.sprite = sprites[1];
        cenasDoJogo = this.GetComponent<Image>();
        cenasDoJogo.sprite = sprites[1];
        //Inicializando as variaveis de verifição
        verificadorDeRota = 0;
        index = 1;
        rotas = 0;
        bttIndex = 0;
        //Posicionando o botão de continuar na tela
        bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
    }
    //
    void Update()
    {
        //Atualizando as informações do personagem no menu a todo momento.
        // textOrcamento.GetComponent<Text>().text = "R$" + orcamento.ToString();
        // textSaude.GetComponent<Text>().text = saude.ToString();
        // textForca.GetComponent<Text>().text = forca.ToString();
        // textAgilidade.GetComponent<Text>().text = agilidade.ToString();
        // textRapidez.GetComponent<Text>().text = rapidez.ToString();
        // textBonus.GetComponent<Text>().text = pontoBonus.ToString();
        
    }

    //Função para trocar as imagens da cena.
    public void NextChangeImage()
    {
        print(index);
        //Sempre ao clicar em continuar, adicionar +1 no index
        index++;
        //Quando a imagem na tela for a numero 7, chamar o primeiro grupo de botões
        //para selecionar uma decisão;
        if (index == 8 && verificadorDeRota == 0)
        {
            rotas = 1;
        }
        
        else if (index == 7 && verificadorDeRota == 9)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Comprar o livro sobre o museu e a casa";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Seguir o Homem";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-1274, 935), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-306, 935), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }
        else if (index == 8 && verificadorDeRota == 8)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se você tem dinheiro, comprar livro";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se não tem dinheiro, ir para casa mesmo assim";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-1222, 925), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-515, 925), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }
        else if (index == 3 && verificadorDeRota == 11)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se a sua agilidade é 3 ou mais";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se a sua agilidade é 2 ou menos";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-480, 914), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-1236, 914), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }

        else if (index == 4 && verificadorDeRota == 5)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Decidir fugir";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Enfrentar! Se a soma da sua Força com sua Agilidade for 6 ou mais";
            GameObject.Find("BttOption03").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Enfrentar! Se a soma da sua Força com a sua Agilidade for 5 ou menos";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-1431, 998), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-850, 894), 0.25f);
            bttOption03.DOAnchorPos(new Vector2(-478, 998), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }
        else if (index == 5 && verificadorDeRota == 18)
        {
            //Alterando o texto dos botões
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se a sua rapidez é 4 ou mais";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se a sua rapidez é 3 ou menos";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-480, 914), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-1236, 914), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }
        else if (index == 4 && verificadorDeRota == 22)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se quiser usar o dinheiro para pagar dívidas e aproveitar para comprar uma \r\ncasa nova bem maior, três carros, móveis novos e TV de plasma";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se quiser usar o dinheiro para pagar dívidas, reformar a casa, guardando mais da metade para investir";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-1035, 1008), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-860, 892), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }
        else if (index == 3 && verificadorDeRota == 17)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Ir para a loja comprar o livro sobre o museu e a casa";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Não perder tempo com isso e correr direto para a casa";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-814, 1436), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-536, 945), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }

        else if (index == 7 && verificadorDeRota == 12)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Comprar o livro sobre o museu e a casa";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Seguir o Homem";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-1274, 935), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-306, 935), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }
        else if (index == 7 && verificadorDeRota == 4)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Comprar o livro sobre o museu e a casa";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Seguir o Homem";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-1274, 935), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-306, 935), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }
        else if (index == 4 && verificadorDeRota == 3)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Tentar escalar a goiabeira para entrar no pomar";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Seguir para o portãozinho";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-1138, 915), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-411, 915), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }
        else if (index == 3 && verificadorDeRota == 13)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se a sua agilidade é 3 ou mais";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se a sua agilidade é 2 ou menos";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-480, 914), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-1236, 914), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }
        else if (index == 6 && verificadorDeRota == 6)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se a sua força é 3 ou mais";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se a sua força é 2 ou menos";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-1264, 914), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-463, 914), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }
        else if (index == 3 && verificadorDeRota == 20)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se a sua força é 3 ou mais";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se a sua força é 2 ou menos";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-1264, 914), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-463, 914), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }
        else if (index == 3 && verificadorDeRota == 23)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se a sua agilidade é 3 ou mais";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se a sua agilidade é 2 ou menos";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-480, 914), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-1236, 914), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }
        else if (index == 4 && verificadorDeRota == 2)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se tiver comprado a pá";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se não tiver comprado";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-1326, 999), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-379, 999), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }
        else if (index == 5 && verificadorDeRota == 7)
        {
            //Alterando o texto dos botões
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se a sua rapidez é 4 ou mais";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se a sua rapidez é 3 ou menos";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-480, 914), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-1236, 914), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }
        else if (index == 4 && verificadorDeRota == 16)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Decidir fugir";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Enfrentar! Se a soma da sua Força com sua Agilidade for 6 ou mais";
            GameObject.Find("BttOption03").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Enfrentar! Se a soma da sua Força com a sua Agilidade for 5 ou menos";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-1431, 998), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-850, 894), 0.25f);
            bttOption03.DOAnchorPos(new Vector2(-478, 998), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }
        else if (index == 5 && verificadorDeRota == 24)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se quiser usar o dinheiro para pagar dívidas e aproveitar para comprar uma \r\ncasa nova bem maior, três carros, móveis novos e TV de plasma";
            GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Se quiser usar o dinheiro para pagar dívidas, reformar a casa, guardando mais da metade para investir";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(-1035, 1008), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-860, 892), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        }

        if (index == 3 && verificadorDeRota == 6)
        {
            jogador.saude -= 1;
        }
        if (index == 2 && verificadorDeRota == 14)
        {
            jogador.saude -= 1;
        }
        if (index == 3 && verificadorDeRota == 15)
        {
            jogador.saude -= 3;
        }
        if (index == 1 && verificadorDeRota == 18)
        {
            jogador.saude -= 1;
        }
        

        //Método que diz o que acontece em cada rota que o usuário escolher
        switch (rotas)
        {
            case 1:
                GameObject.Find("BttOption02").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Acompanhar os colegas";
                GameObject.Find("BttOption01").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Verificar o quiosque";
                GameObject.Find("BttOption03").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Comer lanche que seus pais prepararam";
                
                InicioGame();
                break;
            case 2:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 02", typeof(Sprite)).Cast<Sprite>().ToArray();

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);

                verificadorDeRota = 2;
                bttIndex = 6;
                rotas = 0;
                break;
            
            case 3:

                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 03", typeof(Sprite)).Cast<Sprite>().ToArray();

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);

                verificadorDeRota = 3;
                bttIndex = 3;
                rotas = 0;
                break;

            case 4:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 04", typeof(Sprite)).Cast<Sprite>().ToArray();
                //spriteRender.sprite = sprites[index];

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);

                verificadorDeRota = 4;
                bttIndex = 1;
                rotas = 0;
                break;
            case 5:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 05", typeof(Sprite)).Cast<Sprite>().ToArray();

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 5;
                bttIndex = 4;
                rotas = 0;
                break;
            
        case 6:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 06", typeof(Sprite)).Cast<Sprite>().ToArray();

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 6;
                bttIndex = 5;
                rotas = 0;
                break;
            
            case 7:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 07", typeof(Sprite)).Cast<Sprite>().ToArray();
                //spriteRender.sprite = sprites[0];

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 7;
                bttIndex = 7;
                rotas = 0;
                break;

            case 8:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 08", typeof(Sprite)).Cast<Sprite>().ToArray();
                //spriteRender.sprite = sprites[0];

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 8;
                bttIndex = 2;
                rotas = 0;
                break;

            case 9:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 09", typeof(Sprite)).Cast<Sprite>().ToArray();
                //spriteRender.sprite = sprites[index];

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);

                verificadorDeRota = 9;
                bttIndex = 1;
                rotas = 0;
                break;
            
             case 10:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 10", typeof(Sprite)).Cast<Sprite>().ToArray();

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 10;
                bttIndex = 5;
                rotas = 0;
                break;
            
            case 11:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 11", typeof(Sprite)).Cast<Sprite>().ToArray();

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);

                verificadorDeRota = 11;
                bttIndex = 3;
                rotas = 0;
                break;

            case 12:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 12", typeof(Sprite)).Cast<Sprite>().ToArray();
                //spriteRender.sprite = sprites[index];

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);

                verificadorDeRota = 12;
                bttIndex = 1;
                rotas = 0;
                break;
            
            case 13:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 13", typeof(Sprite)).Cast<Sprite>().ToArray();
                //spriteRender.sprite = sprites[index];

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);

                verificadorDeRota = 13;
                bttIndex = 4;
                rotas = 0;
                break;

            case 14:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 14", typeof(Sprite)).Cast<Sprite>().ToArray();

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 14;
                bttIndex = 4;
                rotas = 0;
                break;
            
            case 15:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 15", typeof(Sprite)).Cast<Sprite>().ToArray();

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 15;
                bttIndex = 5;
                rotas = 0;
                break;
            
            case 16:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 16", typeof(Sprite)).Cast<Sprite>().ToArray();
                //spriteRender.sprite = sprites[0];

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 16;
                bttIndex = 7;
                rotas = 0;
                break;

            case 17:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 17", typeof(Sprite)).Cast<Sprite>().ToArray();
                //spriteRender.sprite = sprites[0];

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 17;
                bttIndex = 2;
                rotas = 0;
                break;

            case 18:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 18", typeof(Sprite)).Cast<Sprite>().ToArray();

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 18;
                bttIndex = 5;
                rotas = 0;
                break;
               
            case 19:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 19", typeof(Sprite)).Cast<Sprite>().ToArray();

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 19;
                bttIndex = 6;
                rotas = 0;
                break;
                
           case 20:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 20", typeof(Sprite)).Cast<Sprite>().ToArray();
                //spriteRender.sprite = sprites[index];

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);

                verificadorDeRota = 20;
                bttIndex = 4;
                rotas = 0;
                break;
            case 21:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 21", typeof(Sprite)).Cast<Sprite>().ToArray();

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 21;
                bttIndex = 6;
                rotas = 0;
                break;
            case 22:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 22", typeof(Sprite)).Cast<Sprite>().ToArray();

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 22;
                bttIndex = 6;
                rotas = 0;
                break;
                
           case 23:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 23", typeof(Sprite)).Cast<Sprite>().ToArray();

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 23;
                bttIndex = 5;
                rotas = 0;
                break;
            
            case 24:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 24", typeof(Sprite)).Cast<Sprite>().ToArray();

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 24;
                jogador.saude -= 1;
                bttIndex = 8;
                rotas = 0;
                break;

            case 25:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 25", typeof(Sprite)).Cast<Sprite>().ToArray();

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 25;
                bttIndex = 7;
                rotas = 0;
                break;
            case 26:
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 26", typeof(Sprite)).Cast<Sprite>().ToArray();

                bttNext.DOAnchorPos(new Vector2(1724, -922), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                verificadorDeRota = 26;
                bttIndex = 7;
                rotas = 0;
                break;
                
        }
        //spriteRenderer.sprite = sprites[index];
        cenasDoJogo.sprite = sprites[index];

    }

    //IMPORTANTE********************************************************
    //Verificar se não possui uma forma de aperfeiçoar essa verificação.
    public void LoadScene(string name)
    {
        
        if (index == 5 && verificadorDeRota == 14)
        {
            //Carregar cena de acordo com seu nome
            SceneManager.LoadScene(name);
        }
        else if (index == 4 && verificadorDeRota == 10)
        {
            //Carregar cena de acordo com seu nome
            SceneManager.LoadScene(name);
        }
        else if (index == 7 && verificadorDeRota == 15)
        {
            //Carregar cena de acordo com seu nome
            SceneManager.LoadScene(name);
        }
        else if (index == 5 && verificadorDeRota == 19)
        {
            //Carregar cena de acordo com seu nome
            SceneManager.LoadScene(name);
        }
        else if (index == 3 && verificadorDeRota == 25)
        {
            //Carregar cena de acordo com seu nome
            SceneManager.LoadScene(name);
        }
        else if (index == 5 && verificadorDeRota == 26)
        {
            //Carregar cena de acordo com seu nome
            SceneManager.LoadScene(name);
        }
        else if (index == 4 && verificadorDeRota == 21)
        {
            //Carregar cena de acordo com seu nome
            SceneManager.LoadScene(name);
        }


    }

    //IMPORTANTE*****************************************************
    //Realizar as verificações de orçamento, agilidade, rapidez e força. 
    /*Rotas que precisam de verificação: Rota 02, Rota 03, Rota 04
      Rota 05, Rota 07, Rota 09, Rota 18, Rota 22, Rota 24.
    */
    //Decrementar ponto de saude ou orçamento nas rotas que precisar.
    //Alterar a imagem das cenas que tiverem os balões de fala muito pequenos.

    public void InicioGame()
    {
        bttNext.DOAnchorPos(new Vector2(1724, -1488), 0.25f);
        bttOption01.DOAnchorPos(new Vector2(-1441, 1337), 0.25f);
        bttOption02.DOAnchorPos(new Vector2(-233, 1471), 0.25f);
        bttOption03.DOAnchorPos(new Vector2(-311, 1042), 0.25f);
        
        verificadorDeRota = 0;
    }

    //Rota 04, 17, 03...
    public void RotaOption01()
    {

        try
        {
            //rota 04
            if (bttIndex == 0)
            {
                
                if (jogador.usarOrcamento(10))
                {
                    rotas = 4;
                    NextChangeImage();
                }
                else
                {
                    textErro.GetComponent<Text>().text = "Você não tem dinheiro o suficiente!";
                    OpenPanelErro();
                }

            }

            else if ((bttIndex == 1 && verificadorDeRota == 9) || (bttIndex == 2 && verificadorDeRota == 17) || (bttIndex == 1 && verificadorDeRota == 12) || (bttIndex == 1 && verificadorDeRota == 4))
            {
                rotas = 8;
                NextChangeImage();
            }

            else if (bttIndex == 2 && verificadorDeRota == 8)
            {
                if (jogador.usarOrcamento(10))
                {
                    rotas = 3;
                    NextChangeImage();
                }
                else
                {
                    textErro.GetComponent<Text>().text = "Você não tem dinheiro o suficiente!";
                    OpenPanelErro();
                }
                
            }

            else if (bttIndex == 3 && verificadorDeRota == 11)
            {
                
                if (jogador.agilidade >= 3)
                {
                    rotas = 5;
                    NextChangeImage();


                }
                else
                {
                    textErro.GetComponent<Text>().text = "Você não tem agilidade suficiente!";
                    OpenPanelErro();

                }
            }
            else if (bttIndex == 4 && verificadorDeRota == 5)
            {
                rotas = 10;
                NextChangeImage();
            }
            else if ((bttIndex == 5 && verificadorDeRota == 18 && jogador.rapidez >= 4) || (bttIndex == 7 && verificadorDeRota == 7 && jogador.rapidez >= 4))
            {
                rotas = 22;
                NextChangeImage();

                if (jogador.rapidez >= 4)
                {
                    rotas = 22;
                    NextChangeImage();



                }
                else if ((bttIndex == 7 && verificadorDeRota == 16))
                {
                    rotas = 22;
                    NextChangeImage();
                }
                else
                {
                    textErro.GetComponent<Text>().text = "Você não tem rapidez suficiente!";
                    OpenPanelErro();

                } 
            }
            else if ((bttIndex == 6 && verificadorDeRota == 22) || (bttIndex == 8 && verificadorDeRota == 24))
            {
                rotas = 25;
                NextChangeImage();
            }
            //Rota 03
            else if ((bttIndex == 2 && verificadorDeRota == 8 ))
            {
                if (jogador.usarOrcamento(10))
                {
                    rotas = 3;
                    NextChangeImage();
                }
                else
                {
                    textErro.GetComponent<Text>().text = "Você não tem dinheiro o suficiente!";
                    OpenPanelErro();
                }
            }
            //Rota 02
            else if ((bttIndex == 3 && verificadorDeRota == 3))
            {
                rotas = 13;
                NextChangeImage();
            }

            else if ((bttIndex == 4 && verificadorDeRota == 20) || (bttIndex == 5 && verificadorDeRota == 23) || (bttIndex == 5 && verificadorDeRota == 6))
            {
                

               if (jogador.forca >= 3 || jogador.agilidade >=3){
                        rotas = 2;
                        NextChangeImage();
                  
                    
                }
                else
                {
                    textErro.GetComponent<Text>().text = "Você não tem força ou agilidade suficiente!";
                    OpenPanelErro();
                
                }
            }
            else if (bttIndex == 6 && verificadorDeRota == 2)
            {
                

                if (jogador.usarOrcamento(15))
                {
                    rotas = 7;
                    atualizarDadosNoMenuDeAtributos();
                    NextChangeImage();
                }
                else
                {
                    textErro.GetComponent<Text>().text = "Você não tem dinheiro o suficiente!";
                    OpenPanelErro();
                }
            }

        }
        catch (Exception e)
        {
            Debug.Log("ERRO!" + e);
        }

    }

    //Rota 09, 08, 11...
    public void RotaOption02()
    {
        try
        {
            //rota 09
            if (bttIndex == 0)
            {
                

                if (jogador.usarOrcamento(16))
                {
                    rotas = 9;
                    atualizarDadosNoMenuDeAtributos();
                    NextChangeImage();
                }
                else
                {
                    textErro.GetComponent<Text>().text = "Você não tem dinheiro o suficiente!";
                    OpenPanelErro();
                }



            }
         
            else if (bttIndex == 1)
            {
                rotas = 17;
                NextChangeImage();
            }

            else if ((bttIndex == 2 && verificadorDeRota == 8) || (bttIndex == 2 && verificadorDeRota == 17))
            {
                rotas = 11;
                NextChangeImage();
            }

            else if (bttIndex == 3 && verificadorDeRota == 11)
            {
                rotas = 14;
                NextChangeImage();
            }
            else if (bttIndex == 1 && verificadorDeRota == 9 || (bttIndex == 1 && verificadorDeRota == 12) || (bttIndex == 1 && verificadorDeRota == 4))
            {
                rotas = 17;
                NextChangeImage();
            }
            else if (bttIndex == 4 && verificadorDeRota == 5)
            {
                

                if ((jogador.forca + jogador.agilidade) >= 6)
                {
                    rotas = 18;
                    NextChangeImage();


                }
                else
                {
                    textErro.GetComponent<Text>().text = "A soma da força + agilidade não é o suficiente!";
                    OpenPanelErro();

                }
            }
            else if ((bttIndex == 5 && verificadorDeRota == 18) || (bttIndex == 7 && verificadorDeRota == 7))
            {
                rotas = 19;
                NextChangeImage();
            }
            else if ((bttIndex == 6 && verificadorDeRota == 22) || (bttIndex == 8 && verificadorDeRota == 24))
            {
                rotas = 26;
                NextChangeImage();
            }
            else if (bttIndex == 4 && verificadorDeRota == 13)
            {
                rotas = 6;
                NextChangeImage();
            }
            else if (bttIndex == 5 && verificadorDeRota == 6)
            {
                rotas = 21;
                NextChangeImage();
            }
            else if ((bttIndex == 3 && verificadorDeRota == 3))
            {
                rotas = 20;
                NextChangeImage();
            }
            else if ((bttIndex == 4 && verificadorDeRota == 20))
            {
                rotas = 23;
                NextChangeImage();
            }
            else if (bttIndex == 5 && verificadorDeRota == 23)
            {
                rotas = 14;
                NextChangeImage();
            }
            else if (bttIndex == 6 && verificadorDeRota == 2)
            {
                rotas = 16;
                NextChangeImage();
            }
            else if (bttIndex == 7 && verificadorDeRota == 16)
            {
                

                if ((jogador.forca + jogador.agilidade) >= 6)
                {
                    rotas = 24;
                    NextChangeImage();


                }
                else
                {
                    textErro.GetComponent<Text>().text = "A soma da força + agilidade não é o suficiente!";
                    OpenPanelErro();

                }
            }


        }
        catch (Exception e)
        {
            Debug.Log("ERRO!" + e);
        }

    }

    //Rota 12...
    public void RotaOption03()
    {
        //rota 12
        if (bttIndex == 0)
        {
            rotas = 12;
            NextChangeImage();
        }
        //Rota 15
        else if ((bttIndex == 4 && verificadorDeRota == 5) || (bttIndex == 7 && verificadorDeRota == 16))
        {
            rotas = 15;
            NextChangeImage();
        }
        
    }
  
    public void AddPontosForca()
    {
        // if (pontoBonus >= 1 && pontoBonus < 4)
        // {
        //     forca += 1;
        //     pontoBonus -= 1;
        // }
        if(jogador.usarBonus(1, "FORCA")){
            Debug.Log($"Bonus: {jogador.bonus}");
        }else{
            Debug.LogError($"Erro: bonus: {jogador.bonus}");
        }

        atualizarDadosNoMenuDeAtributos();
    }
    public void AddPontosAgilidade()
    {
        // if (pontoBonus >= 1 && pontoBonus < 4)
        // {
        //     agilidade += 1;
        //     pontoBonus -= 1;
        // }
        if(jogador.usarBonus(1, "AGILIDADE")){
            Debug.Log($"Bonus: {jogador.bonus}");
        }else{
            Debug.LogError($"Erro: bonus: {jogador.bonus}");
        }

        atualizarDadosNoMenuDeAtributos();
    }
    public void AddPontosRapidez()
    {
        // if (pontoBonus >= 1 && pontoBonus < 4)
        // {
        //     rapidez += 1;
        //     pontoBonus -= 1;
        // }
        if(jogador.usarBonus(1, "RAPIDEZ")){
            Debug.Log($"Bonus: {jogador.bonus}");
        }else{
            Debug.LogError($"Erro: bonus: {jogador.bonus}");
        }
        atualizarDadosNoMenuDeAtributos();
    }
    public void AddPontosSaude()
    {
        // if (pontoBonus >= 1 && pontoBonus < 4){
        //     saude += 1;
        //     pontoBonus -= 1;
        // }

        if(jogador.usarBonus(1, "SAUDE")){
            Debug.Log($"Bonus: {jogador.bonus}");
        }else{
            Debug.LogError($"Erro: bonus: {jogador.bonus}");
        }

        atualizarDadosNoMenuDeAtributos();
    }

    public void atualizarDadosNoMenuDeAtributos(){
        // Joga o dado do usuário dentro dos textos.
        textOrcamento.GetComponent<Text>().text = "R$" + jogador.orcamento.ToString();
        textSaude.GetComponent<Text>().text = jogador.saude.ToString();
        textForca.GetComponent<Text>().text = jogador.forca.ToString();
        textAgilidade.GetComponent<Text>().text = jogador.agilidade.ToString();
        textRapidez.GetComponent<Text>().text = jogador.rapidez.ToString();
        textBonus.GetComponent<Text>().text = jogador.bonus.ToString();
    }

    public void OpenPanelErro()
    {
        Debug.Log(jogador.nome);
        bool isActive = PanelErro.activeSelf;
        if (PanelErro != null)
        {
            PanelErro.SetActive(!isActive);

        }
        else
        {
            PanelErro.SetActive(isActive);

        }


    }
}
