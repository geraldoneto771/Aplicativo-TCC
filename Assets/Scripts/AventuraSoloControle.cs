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
    //Vetor de imagens contendo as cenas da aventura
    public Sprite[] sprites;
    SpriteRenderer spriteRender;

    int verificadorDeRota;

    //public Sprite cena;
    
    //Verificador de rota
    int rotas;
    //Verificador da posição do vetor de sprites
    int index;
    //botoões
    public RectTransform bttNext, bttOption01, bttOption02, bttOption03;
    //textos
    public GameObject textOrcamento, textSaude, textForca, textAgilidade, textRapidez, textBonus;
    //Pontuação
    int forca = 3, agilidade = 2, rapidez = 3, saude = 5, pontoBonus = 3;
    float orcamento = 25;
    //Verificador de grupo de botões
    int bttIndex;
    //public GameObject cenas;
    // Start is called before the first frame update
    void Start()
    {
        sprites = Resources.LoadAll("Cenas Decisão 01 - Inicio", typeof(Sprite)).Cast<Sprite>().ToArray();
        // cenas = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //spriteRender = GetComponent<SpriteRenderer>();
        //sprites = Resources.LoadAll("AventuraSolo/Cenas Decisão 01 - Inicio/Img001_Rota01_Cena01", typeof(Sprite)).Cast<Sprite>().ToArray();
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.sprite = sprites[1];
        //SetupSprites();
        //cena = Resources.Load<Sprite>("AventuraSolo/Cenas Decisão 01 - Inicio/Img001_Rota01_Cena01");
        //Inicializando as variaveis de verifição
        verificadorDeRota = 0;
        index = 0;
        rotas = 0;
        bttIndex = 0;
        //Posicionando o botão de continuar na tela
        bttNext.DOAnchorPos(new Vector2(-142, 77), 0.25f);
        //Habilitando o acesso ao componente SpriteRenderer do sprite
        //spriteRender = GetComponent<SpriteRenderer>();
        //Inicializando o sprite na posição zero do vetor.
        
        
        //spriteRender.cenas = GameObject.CreatePrimitive(PrimitiveType.Plane);
    }
    void Update()
    {
        //Atualizando as informações do personagem no menu a todo momento.
        textOrcamento.GetComponent<Text>().text = "R$" + orcamento.ToString();
        textSaude.GetComponent<Text>().text = saude.ToString();
        textForca.GetComponent<Text>().text = forca.ToString();
        textAgilidade.GetComponent<Text>().text = agilidade.ToString();
        textRapidez.GetComponent<Text>().text = rapidez.ToString();
        textBonus.GetComponent<Text>().text = pontoBonus.ToString();

    }

    void SetupSprites()
    {
        //sprites = Resources.LoadAll("AventuraSolo/Cenas Decisão 01 - Inicio", typeof(Sprite)).Cast<Sprite>().ToArray();
       // sprites = Resources.LoadAll("Images", typeof(Sprite));
    }
    

    //Função para trocar as imagens da cena.
    public void NextChangeImage()
    {
        //Sempre ao clicar em continuar, adicionar +1 no index
        index++;

        //Quando a imagem na tela for a numero 7, chamar o primeiro grupo de botões
        //para selecionar uma decisão;
        if (index == 8)
        {
            rotas = 1;
        }

        //Quando a imagem na tela for a numero 15, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 15)
        {
            bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);
            //bttRota08.DOAnchorPos(new Vector2(-341, 207), 0.25f);
            // bttRota17.DOAnchorPos(new Vector2(385, 215), 0.25f);

        }

        //Quando a imagem na tela for a numero 23, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 23)
        {

            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<Text>().text = "Comprar o livro sobre o museu e a casa";
            GameObject.Find("BttOption02").GetComponentInChildren<Text>().text = "Seguir o Homem";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(495, -281), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-501, -281), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);

        }

        //Quando a imagem na tela for a numero 31, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 31)
        {
            // bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);
            // bttRota08.DOAnchorPos(new Vector2(-341, 207), 0.25f);
            // bttRota17.DOAnchorPos(new Vector2(385, 215), 0.25f);

        }

        //Quando a imagem na tela for a numero 35, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 35)
        {
            // bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);
            // bttRota08.DOAnchorPos(new Vector2(-341, 207), 0.25f);
            // bttRota11.DOAnchorPos(new Vector2(345, 207), 0.25f);

        }

        //Quando a imagem na tela for a numero 39, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 39)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<Text>().text = "Se a sua agilidade é 3 ou mais";
            GameObject.Find("BttOption02").GetComponentInChildren<Text>().text = "Se a sua agilidade é 2 ou menos";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(495, -330), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-501, -330), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);

        }

        //Quando a imagem na tela for a numero 54, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 54)
        {
            //Alterando o texto dos botões
            GameObject.Find("BttOption01").GetComponentInChildren<Text>().text = "Se você tem dinheiro, comprar livro";
            GameObject.Find("BttOption02").GetComponentInChildren<Text>().text = "Se não tem dinheiro, ir para casa mesmo assim";

            //Setando os botões de escolha na tela
            bttOption01.DOAnchorPos(new Vector2(495, -281), 0.25f);
            bttOption02.DOAnchorPos(new Vector2(-501, -281), 0.25f);

            //setando o botão de continuar fora da tela
            bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);

        }

        //Quando a imagem na tela for a numero 59, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 59)
        {
            // bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);
            // bttRota10.DOAnchorPos(new Vector2(299, 189), 0.25f);
            // bttRota15.DOAnchorPos(new Vector2(-87, 189), 0.25f);
            // bttRota18.DOAnchorPos(new Vector2(-374, 189), 0.25f);

        }

        //Quando a imagem na tela for a numero 78, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 78)
        {
            // bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);
            // bttRota19.DOAnchorPos(new Vector2(415, 164), 0.25f);
            // bttRota22.DOAnchorPos(new Vector2(586, 164), 0.25f);


        }

        //Quando a imagem na tela for a numero 89, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 89)
        {
            // bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);
            //bttRota25.DOAnchorPos(new Vector2(600, 122), 0.25f);
            //bttRota26.DOAnchorPos(new Vector2(-575, 334), 0.25f);


        }

        //Quando a imagem na tela for a numero 104, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 104)
        {
            // bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);
            // bttRota13.DOAnchorPos(new Vector2(366, 174), 0.25f);
            // bttRota20.DOAnchorPos(new Vector2(-333, 174), 0.25f);


        }

        //Quando a imagem na tela for a numero 108, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 108)
        {
            // bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);
            // bttRota02.DOAnchorPos(new Vector2(329, 192), 0.25f);
            // bttRota14.DOAnchorPos(new Vector2(-320, 192), 0.25f);


        }

        //Quando a imagem na tela for a numero 112, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 112)
        {
            //  bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);
            // bttRota02.DOAnchorPos(new Vector2(329, 192), 0.25f);
            // bttRota14.DOAnchorPos(new Vector2(-320, 192), 0.25f);


        }

        //Quando a imagem na tela for a numero 117, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 117)
        {
            // bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);
            //  bttRota07.DOAnchorPos(new Vector2(300, 128), 0.25f);
            //  bttRota16.DOAnchorPos(new Vector2(-300, 128), 0.25f);


        }

        //Quando a imagem na tela for a numero 123, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 123)
        {
            //  bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);
            //  bttRota19.DOAnchorPos(new Vector2(415, 164), 0.25f);
            //  bttRota22.DOAnchorPos(new Vector2(586, 164), 0.25f);


        }

        //Quando a imagem na tela for a numero128, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 128)
        {
            //  bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);
            //  bttRota15.DOAnchorPos(new Vector2(0, 164), 0.25f);
            //  bttRota22.DOAnchorPos(new Vector2(-315, 164), 0.25f);
            //  bttRota24.DOAnchorPos(new Vector2(315, 164), 0.25f);


        }

        //Quando a imagem na tela for a numero 134, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 134)
        {
            //  bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);
            //  bttRota25.DOAnchorPos(new Vector2(600, 122), 0.25f);
            //  bttRota26.DOAnchorPos(new Vector2(-575, 334), 0.25f);


        }

        //Quando a imagem na tela for a numero 138, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 138)
        {
            //  bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);
            //  bttRota02.DOAnchorPos(new Vector2(329, 171), 0.25f);
            //  bttRota06.DOAnchorPos(new Vector2(-384, 171), 0.25f);


        }

        //Quando a imagem na tela for a numero 145, chamar o proximo grupo de botões
        //para selecionar uma decisão;
        if (index == 145)
        {
            //  bttNext.DOAnchorPos(new Vector2(1204, -912), 0.25f);
            // bttRota02.DOAnchorPos(new Vector2(329, 171), 0.25f);
            // bttRota21.DOAnchorPos(new Vector2(-329, 171), 0.25f);


        }

        //Método que diz o que acontece em cada rota que o usuário escolher
        switch (rotas)
        {
            case 1:
                GameObject.Find("BttOption02").GetComponentInChildren<Text>().text = "Acompanhar os colegas";
                GameObject.Find("BttOption01").GetComponentInChildren<Text>().text = "Verificar o quiosque";
                GameObject.Find("BttOption03").GetComponentInChildren<Text>().text = "Comer lanche que seus pais prepararam";
                
                InicioGame();
                break;
            /*case 2:
                index = 113;
                bttNext.DOAnchorPos(new Vector2(-149, 61), 0.25f);
                bttRota02.DOAnchorPos(new Vector2(-631, 4083), 0.25f);
                bttRota23.DOAnchorPos(new Vector2(660, 4083), 0.25f);
                bttRota21.DOAnchorPos(new Vector2(596, 3565), 0.25f);
                bttRota06.DOAnchorPos(new Vector2(1286, 3171), 0.25f);
                bttRota14.DOAnchorPos(new Vector2(3458, 2632), 0.25f);
                rotas = 0;
                break;
            */
            case 3:
                
                index = 100;
                bttNext.DOAnchorPos(new Vector2(-142, 77), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                bttIndex = 3;
                rotas = 0;
                break;

            case 4:
                index = 8;
                bttNext.DOAnchorPos(new Vector2(-142, 77), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                rotas = 0;
                break;
            case 5:
                index = 55;
                bttNext.DOAnchorPos(new Vector2(-142, 77), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                bttIndex = 4;
                rotas = 0;
                break;
                /*
            case 6:
                index = 139;
                bttNext.DOAnchorPos(new Vector2(-149, 61), 0.25f);
                bttRota06.DOAnchorPos(new Vector2(1286, 3171), 0.25f);
                bttRota02.DOAnchorPos(new Vector2(-631, 4083), 0.25f);
                saude -= 1;
                rotas = 0;
                break;
            case 7:
                index = 118;
                bttNext.DOAnchorPos(new Vector2(-149, 61), 0.25f);
                bttRota07.DOAnchorPos(new Vector2(-660, 4556), 0.25f);
                bttRota16.DOAnchorPos(new Vector2(660, 4697), 0.25f);
                rotas = 0;
                
                break;
             */
            case 8:
                index = 46;

                bttNext.DOAnchorPos(new Vector2(-142, 77), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                bttIndex = 2;
                rotas = 0;
                break;

            case 9:
               
                
                index = 0;

                sprites = Resources.LoadAll("Cenas Decisão 09", typeof(Sprite)).Cast<Sprite>().ToArray();
                spriteRender.sprite = sprites[0];
                bttNext.DOAnchorPos(new Vector2(-142, 77), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                bttIndex = 1;
                
                rotas = 0;

                break;
            /*
             case 10:
                 index = 60;
                 bttNext.DOAnchorPos(new Vector2(-149, 61), 0.25f);
                 bttRota10.DOAnchorPos(new Vector2(-661, 2934), 0.25f);
                 bttRota15.DOAnchorPos(new Vector2(-87, 2934), 0.25f);
                 bttRota18.DOAnchorPos(new Vector2(586, 2934), 0.25f);
                 rotas = 0;
                 break;
            */
             case 11:
                index = 36;
                bttNext.DOAnchorPos(new Vector2(-142, 77), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                bttIndex = 3;
                rotas = 0;
                break;

            case 12:
                index = 24;
                bttNext.DOAnchorPos(new Vector2(-142, 77), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                bttIndex = 1;
                rotas = 0;
                break;
            /*
        case 13:
            index = 135;
            bttNext.DOAnchorPos(new Vector2(-149, 61), 0.25f);
            bttRota13.DOAnchorPos(new Vector2(-594, 4338), 0.25f);
            bttRota20.DOAnchorPos(new Vector2(627, 4338), 0.25f);
            rotas = 0;
            break;
            */
        case 14:
            index = 40;
                bttNext.DOAnchorPos(new Vector2(-142, 77), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                bttIndex = 4;
                rotas = 0;
                break;
            /*
    case 15:
        index = 65;
        bttNext.DOAnchorPos(new Vector2(-149, 61), 0.25f);
        bttRota10.DOAnchorPos(new Vector2(-661, 2934), 0.25f);
        bttRota15.DOAnchorPos(new Vector2(-87, 2934), 0.25f);
        bttRota18.DOAnchorPos(new Vector2(586, 2934), 0.25f);
        bttRota22.DOAnchorPos(new Vector2(586, 3355), 0.25f);
        bttRota24.DOAnchorPos(new Vector2(-24, 4891), 0.25f);
        saude -= 3;
        rotas = 0;
        break;
    case 16:
        index = 124;
        bttNext.DOAnchorPos(new Vector2(-149, 61), 0.25f);
        bttRota07.DOAnchorPos(new Vector2(-660, 4556), 0.25f);
        bttRota16.DOAnchorPos(new Vector2(660, 4697), 0.25f);
        rotas = 0;
        break;
        */
            case 17:
                index = 32;
                bttNext.DOAnchorPos(new Vector2(-142, 77), 0.25f);
                bttOption01.DOAnchorPos(new Vector2(-703, 2601), 0.25f);
                bttOption02.DOAnchorPos(new Vector2(-103, 2595), 0.25f);
                bttOption03.DOAnchorPos(new Vector2(530, 2624), 0.25f);
                bttIndex = 2;
                rotas = 0;
                break;
                /*
            case 18:
                index = 73;
                bttNext.DOAnchorPos(new Vector2(-149, 61), 0.25f);
                bttRota10.DOAnchorPos(new Vector2(-661, 2934), 0.25f);
                bttRota15.DOAnchorPos(new Vector2(-87, 2934), 0.25f);
                bttRota18.DOAnchorPos(new Vector2(586, 2934), 0.25f);
                saude -= 1;
                rotas = 0;
                break;
            case 19:
                index = 79;
                bttNext.DOAnchorPos(new Vector2(-149, 61), 0.25f);
                bttRota19.DOAnchorPos(new Vector2(-545, 3355), 0.25f);
                bttRota22.DOAnchorPos(new Vector2(586, 3355), 0.25f);
                rotas = 0;
                break;
            case 20:
                index = 105;
                bttNext.DOAnchorPos(new Vector2(-149, 61), 0.25f);
                bttRota13.DOAnchorPos(new Vector2(-594, 4338), 0.25f);
                bttRota20.DOAnchorPos(new Vector2(627, 4338), 0.25f);
                rotas = 0;
                break;
            case 21:
                index = 146;
                bttNext.DOAnchorPos(new Vector2(-149, 61), 0.25f);
                bttRota21.DOAnchorPos(new Vector2(596, 3565), 0.25f);
                bttRota02.DOAnchorPos(new Vector2(-631, 4083), 0.25f);
                rotas = 0;
                break;
            case 22:
                index = 85;
                bttNext.DOAnchorPos(new Vector2(-149, 61), 0.25f);
                bttRota19.DOAnchorPos(new Vector2(-545, 3355), 0.25f);
                bttRota22.DOAnchorPos(new Vector2(586, 3355), 0.25f);
                bttRota15.DOAnchorPos(new Vector2(-87, 2934), 0.25f);
                bttRota24.DOAnchorPos(new Vector2(-24, 4891), 0.25f);
                rotas = 0;
                break;
            case 23:
                index = 109;
                bttNext.DOAnchorPos(new Vector2(-149, 61), 0.25f);
                bttRota02.DOAnchorPos(new Vector2(-631, 4083), 0.25f);
                bttRota23.DOAnchorPos(new Vector2(660, 4083), 0.25f);
                rotas = 0;
                break;
            case 24:
                index = 129;
                bttNext.DOAnchorPos(new Vector2(-149, 61), 0.25f);
                bttRota22.DOAnchorPos(new Vector2(586, 3355), 0.25f);
                bttRota15.DOAnchorPos(new Vector2(-87, 2934), 0.25f);
                bttRota24.DOAnchorPos(new Vector2(-24, 4891), 0.25f);
                saude -= 1;
                rotas = 0;
                break;
            case 25:
                index = 90;
                bttNext.DOAnchorPos(new Vector2(-149, 61), 0.25f);
                bttRota25.DOAnchorPos(new Vector2(-360, 3678), 0.25f);
                bttRota26.DOAnchorPos(new Vector2(385, 3890), 0.25f);
               
                rotas = 0;
                break;
            case 26:
                index = 94;
                bttNext.DOAnchorPos(new Vector2(-149, 61), 0.25f);
                bttRota25.DOAnchorPos(new Vector2(-360, 3678), 0.25f);
                bttRota26.DOAnchorPos(new Vector2(385, 3890), 0.25f);
                
                rotas = 0;
                break;
                */
        }
        spriteRender.sprite = sprites[index];


    }

    public void LoadScene(string name)
    {
        if (index == 45 || index == 64 || index == 72 || index == 84 || index == 93 || index == 99 || index == 150)
        {
            //Carregar cena de acordo com seu nome
            SceneManager.LoadScene(name);
        }


    }

    public void InicioGame()
    {

        bttOption01.DOAnchorPos(new Vector2(-571, 154), 0.25f);
        bttOption02.DOAnchorPos(new Vector2(601, 270), 0.25f);
        bttOption03.DOAnchorPos(new Vector2(379, -299), 0.25f);
        bttNext.DOAnchorPos(new Vector2(-142, 77), 0.25f);
        verificadorDeRota = 1;
    }
    /*
    public void RotaDois()
    {
        try
        {
            if (forca >= 3 && agilidade >= 3)
            {
                rotas = 2;
                NextChangeImage();
            }
            else
            {
                Debug.Log("Sua for�a n�o � o suficiente, escolha a outra op��o ou verifique se consegue aumentar sua pontua��o!");
            }
        }
        catch (Exception e)
        {
            Debug.Log("ERRO!" + e);
        }


    }
    public void RotaTres()
    {

        try
        {
            if (orcamento >= 10)
            {
                rotas = 3;
                orcamento -= 10;
                NextChangeImage();
            }
            else
            {
                Debug.Log("Voc� n�o tenho dinheiro suficiente, escolha a outra op��o!");
            }
        }
        catch (Exception e)
        {
            Debug.Log("ERRO!" + e);
        }

    }
    */

    //Rota 04, 17, 03...
    public void RotaOption01()
    {

        try
        {
            //rota 04
            if (bttIndex == 0)
            {
                if (orcamento >= 10)
                {
                    rotas = 4;
                    orcamento -= 10;

                    NextChangeImage();

                }
                else
                {
                    Debug.Log("Voc� n�o tenho dinheiro suficiente, escolha a outra op��o!");
                }

            }

            else if (bttIndex == 1)
            {
                rotas = 8;
                NextChangeImage();
            }

            else if (bttIndex == 2)
            {
                rotas = 3;
                NextChangeImage();
            }

            else if (bttIndex == 3)
            {
                rotas = 5;
                NextChangeImage();
            }

        }
        catch (Exception e)
        {
            Debug.Log("ERRO!" + e);
        }

    }
    /*
   
    public void RotaQuinta()
    {
        try
        {
            if (agilidade >= 3)
            {
                rotas = 5;
                NextChangeImage();
            }
            else
            {
                Debug.Log("Sua for�a n�o � o suficiente, escolha a outra op��o ou verifique se consegue aumentar sua pontua��o!");
            }
        }
        catch (Exception e)
        {
            Debug.Log("ERRO!" + e);
        }
    }

    public void RotaSete()
    {     

        try
        {
            if (orcamento >= 15)
            {
                rotas = 7;
                orcamento -= 15;
                NextChangeImage();
            }
            else
            {
                Debug.Log("Voc� n�o tenho dinheiro suficiente, escolha a outra op��o!");
            }
        }
        catch (Exception e)
        {
            Debug.Log("ERRO!" + e);
        }

    }
    */
    //Rota 09, 08, 11...
    public void RotaOption02()
    {
        try
        {
            //rota 09
            if (bttIndex == 0)
            {
                if (orcamento >= 16)
                {
                    rotas = 9;
                    orcamento -= 16;
                    sprites = null;
                    NextChangeImage();
                }
                else
                {
                    Debug.Log("Voc� n�o tenho dinheiro suficiente, escolha a outra op��o!");
                }

            }
         
            else if (bttIndex == 1)
            {
                rotas = 17;
                NextChangeImage();
            }

            else if (bttIndex == 2)
            {
                rotas = 11;
                NextChangeImage();
            }

            else if (bttIndex == 3)
            {
                rotas = 14;
                NextChangeImage();
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
    }
    /* 
    public void RotaDezoito()
    {
        try
        {
            if ((forca + agilidade ) >= 6)
            {
                rotas = 18;
                NextChangeImage();
            }
            else
            {
                Debug.Log("A soma da for�a + agilidade n�o � o suficiente, escolha a outra op��o ou verifique se consegue aumentar sua pontua��o!");
            }
        }
        catch (Exception e)
        {
            Debug.Log("ERRO!" + e);
        }
    }

    public void RotaVinteDois()
    {
        try
        {
            if (rapidez >= 4)
            {
                rotas = 22;
                NextChangeImage();
            }
            else
            {
                Debug.Log("Sua rapidez n�o � o suficiente, escolha a outra op��o ou verifique se consegue aumentar sua pontua��o!");
            }
        }
        catch (Exception e)
        {
            Debug.Log("ERRO!" + e);
        }

    }

    public void RotaVinteQuatro()
    {
        try
        {
            if ((forca + agilidade) >= 6)
            {
                rotas = 24;
                NextChangeImage();
            }
            else
            {
                Debug.Log("A soma da for�a + agilidade n�o � o suficiente, escolha a outra op��o ou verifique se consegue aumentar sua pontua��o!");
            }
        }
        catch (Exception e)
        {
            Debug.Log("ERRO!" + e);
        }
    }
    */
    public void AddPontosForca()
    {
        if (pontoBonus >= 1 && pontoBonus < 4)
        {
            forca += 1;
            pontoBonus -= 1;
        }
    }
    public void AddPontosAgilidade()
    {
        if (pontoBonus >= 1 && pontoBonus < 4)
        {
            agilidade += 1;
            pontoBonus -= 1;
        }
    }
    public void AddPontosRapidez()
    {
        if (pontoBonus >= 1 && pontoBonus < 4)
        {
            rapidez += 1;
            pontoBonus -= 1;
        }
    }
    public void AddPontosSaude()
    {
        if (pontoBonus >= 1 && pontoBonus < 4)
        {
            saude += 1;
            pontoBonus -= 1;
        }
    }
}
