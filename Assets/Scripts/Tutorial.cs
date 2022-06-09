using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private CanvasGroup loadingOverlay;
    [SerializeField]
    private float fadeTime = 0.5f;
    private int verificadorIndexTutorial = 0;
    private Image spritesTutorial;
    public Sprite[] sprites;
    int index;
    public RectTransform ImageTutorial, bttNext, bttExit;
    //public CanvasGroup loadingOverlay2;
    public int sceneIndex = 0;
    //public GameObject PanelTutorial;
    public Jogador jogador;

    // Find Objetos
    Transform pf, pf2, pf3, pf4; 
    Transform bMenu;
    Transform bTuto;
    Transform bConv; 
    Transform bCof;
    Transform bMod;
    Transform bNext;
    Transform bIntro;
    Transform bAve;
    Transform bBack;
    Transform bPros;
    Transform bInfo;
    Transform bCont;
    Transform bVolt;
    Transform bPerfil;
    //Transform bVoltar;


    //Movimentação do tutorial
    private GameObject destino, destino2;
    public bool movendo = false;

    public float velocidade = 1f;

    private float distancia = 0f;
    private float distanciaMinima = 2f;

    public static Tutorial Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        if (sceneIndex == 0 && jogador.tutorialTelaInicial == 0)
        {
            LoadTutorialAsync();
            jogador.tutorialTelaInicial = 1;
        }
        else if(sceneIndex == 1 && jogador.tutorialTelaFases == 0)
        {
           
            LoadLoadTutorialFasesAsync();
            
            jogador.tutorialTelaFases = 1;
        }
        else if(sceneIndex == 2 && jogador.tutorialTelaCofrinho == 0)
        {
            LoadLoadTutorialCofreAsync();
            jogador.tutorialTelaCofrinho = 1;
        }
        else if(sceneIndex == 3 && jogador.tutorialTelaConversor == 0)
        {
            LoadLoadTutorialConversorAsync();
            
            jogador.tutorialTelaConversor = 1;
        }
        else if (sceneIndex == 5 && jogador.tutorialTelaIntroducao == 0)
        {
            LoadLoadTutorialIntroducaoAsync();

            jogador.tutorialTelaIntroducao = 1;
        }
        else if (sceneIndex == 4 && jogador.tutorialTelaAventura == 0)
        {
            LoadLoadTutorialAventuraAsync();

            jogador.tutorialTelaAventura = 1;
        }

        loadingOverlay.blocksRaycasts = false;

    }


    public void LoadTutorialAsync()
    {
        StartCoroutine(FadeIn());
        
        sprites = Resources.LoadAll("TutorialTelaInicial", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = GameObject.Find("ImageTutorial").GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
        //ImageTutorial.DOAnchorPos(new Vector2(42, -52), 0.25f);
        //bttNext.DOAnchorPos(new Vector2(0, 70), 0.25f);
        ImageTutorial.sizeDelta = new Vector2(158, 197);
        destino = GameObject.Find("TitleGame");
        destino2 = GameObject.Find("btt_next_tutorial");
    }

    public void LoadLoadTutorialFasesAsync()
    {
        StartCoroutine(FadeIn());
        
        sprites = Resources.LoadAll("TelaFases", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = GameObject.Find("ImageTutorial").GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
       // ImageTutorial.DOAnchorPos(new Vector2(88, -16), 0.25f);
        //bttNext.DOAnchorPos(new Vector2(0, 70), 0.25f);
        destino = GameObject.Find("btt_introducao_aventura_1");
        pf2 = GameObject.Find("CanvasFase1").transform;
        bIntro = pf2.Find("btt_introducao_aventura_1");
        bIntro.SetSiblingIndex(16);

        bAve = pf2.Find("btt_aventurasolo_1");
        bAve.SetSiblingIndex(7);
        bBack = pf2.Find("ButtonBack");
        bBack.SetSiblingIndex(14);
    }

    public void LoadLoadTutorialCofreAsync()
    {
        StartCoroutine(FadeIn());
        
        sprites = Resources.LoadAll("TelaCofre", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = GameObject.Find("ImageTutorial").GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
        //ImageTutorial.DOAnchorPos(new Vector2(112, -159), 0.25f);
        destino = GameObject.Find("InputFieldAddCofre");
        //bttNext.DOAnchorPos(new Vector2(0, 30), 0.25f);
    }

    public void LoadLoadTutorialConversorAsync()
    {
        StartCoroutine(FadeIn());
        
        sprites = Resources.LoadAll("TelaConversor", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = GameObject.Find("ImageTutorial").GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
        //ImageTutorial.DOAnchorPos(new Vector2(102, -34), 0.25f);
        destino = GameObject.Find("InputFieldMoeda");
        bttNext.DOAnchorPos(new Vector2(0, -29), 0.25f);
    }
    public void LoadLoadTutorialIntroducaoAsync()
    {
        StartCoroutine(FadeIn());
        
        sprites = Resources.LoadAll("TelaIntroducao", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = GameObject.Find("ImageTutorial").GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
        //ImageTutorial.DOAnchorPos(new Vector2(613, -245), 0.25f);
        destino = GameObject.Find("ButtonContinuar");
        pf3 = GameObject.Find("ImageIntro").transform;
        bPros = pf3.Find("ButtonContinuar");
        bPros.SetSiblingIndex(3);
        //bVoltar = pf3.Find("ButtonVoltar");
        //bVoltar.SetSiblingIndex(1);



    }
    public void LoadLoadTutorialAventuraAsync()
    {
        StartCoroutine(FadeIn());
        
        sprites = Resources.LoadAll("TelaAventura", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = GameObject.Find("ImageTutorial").GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
        //ImageTutorial.DOAnchorPos(new Vector2(638, -253), 0.25f);
        destino = GameObject.Find("BttContinuar");
        bttNext.DOAnchorPos(new Vector2(0, 51), 0.25f);

        pf4 = GameObject.Find("ImageCenas").transform;
        
        

    }

    public void LoadLoadTutorialEscolhaRotaAsync()
    {
        StartCoroutine(FadeIn());

        sprites = Resources.LoadAll("EscolhasRotas", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = GameObject.Find("ImageTutorial").GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
        //ImageTutorial.DOAnchorPos(new Vector2(638, -253), 0.25f);
        destino = GameObject.Find("ImageCenas");
        bttNext.DOAnchorPos(new Vector2(0, 51), 0.25f);
    }

    private IEnumerator FadeIn()
    {
        
        float start = 0;
        float end = 1;
        float speed = (end - start) / fadeTime;

        loadingOverlay.alpha = start;
        //loadingOverlay2.alpha = start;
        
        while (loadingOverlay.alpha < end)
        {
            loadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }

        loadingOverlay.alpha = end;
        loadingOverlay.blocksRaycasts = true;
        //loadingOverlay2.alpha = end;

    }
    private IEnumerator FadeOut()
    {
        float start = 1;
        float end = 0;
        float speed = (end - start) / fadeTime;

        loadingOverlay.alpha = start;
       // loadingOverlay2.alpha = start;
        

        while (loadingOverlay.alpha > end)
        {
            loadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }

        loadingOverlay.alpha = end;
        loadingOverlay.blocksRaycasts = false;
        // loadingOverlay2.alpha = end;

    }

    public void NextTutorial()
    {
        print(verificadorIndexTutorial);
        verificadorIndexTutorial++;


        switch (verificadorIndexTutorial)
        {
            case 0:
                destino = GameObject.Find("TitleGame");
                ImageTutorial.sizeDelta = new Vector2(158, 197);
                //ImageTutorial.DOAnchorPos(new Vector2(42, -52), 0.25f);
                break;

            case 1:
                ImageTutorial.transform.localScale = new Vector3(0.94f, 0.96f, 0f);
                pf = GameObject.Find("CanvasTelaIncial").transform;
                bMenu = pf.Find("btt_menu");
                bMenu.SetSiblingIndex(12);
                destino = GameObject.Find("btt_menu");
                //ImageTutorial.DOAnchorPos(new Vector2(42, -52), 0.25f);
                break;

            case 2:
                destino = GameObject.Find("btt_tutorial");
                pf = GameObject.Find("CanvasTelaIncial").transform;
                bTuto = pf.Find("btt_tutorial");
                bMenu.SetSiblingIndex(2);
                bTuto.SetSiblingIndex(12);
                //ImageTutorial.DOAnchorPos(new Vector2(562, -52), 0.25f);
                break;
            case 3:
                ImageTutorial.sizeDelta = new Vector2(190, 197);
                destino = GameObject.Find("btt_conversor");
                pf = GameObject.Find("CanvasTelaIncial").transform;
                bConv = pf.Find("btt_conversor");
                bTuto.SetSiblingIndex(3);
                bConv.SetSiblingIndex(12);
                //ImageTutorial.DOAnchorPos(new Vector2(509, -211), 0.25f);
                break;
            case 4:
                destino = GameObject.Find("btt_cofre");
                pf = GameObject.Find("CanvasTelaIncial").transform;
                bCof = pf.Find("btt_cofre");
                bConv.SetSiblingIndex(5);
                bCof.SetSiblingIndex(12);
                //ImageTutorial.DOAnchorPos(new Vector2(566, -211), 0.25f);
                break;
            case 5:
                ImageTutorial.sizeDelta = new Vector2(156, 197);
                destino = GameObject.Find("btt_modulo_1");
                pf = GameObject.Find("CanvasTelaIncial").transform;
                bMod = pf.Find("Modulos_1_2");
                bCof.SetSiblingIndex(6);
                
                //ImageTutorial.DOAnchorPos(new Vector2(217, -74), 0.25f);
                break;
            case 6:           
                
                ImageTutorial.sizeDelta = new Vector2(190, 197);
                destino = GameObject.Find("btt_next_modulos");
                //ImageTutorial.DOAnchorPos(new Vector2(529, -70), 0.25f);
                break;
                

        }

        spritesTutorial.sprite = sprites[verificadorIndexTutorial];

        //fade out
        if (verificadorIndexTutorial > 6)
        {
            StartCoroutine(FadeOut());
            ImageTutorial.transform.localScale = new Vector3(1f, 1f, 1f);
            ImageTutorial.sizeDelta = new Vector2(156, 197);

            

        }
    }

    public void NextTutorialFases()
    {
        print(verificadorIndexTutorial);
        verificadorIndexTutorial++;


        switch (verificadorIndexTutorial)
        {
            case 0:
                destino = GameObject.Find("btt_introducao_aventura_1");
                //pf = GameObject.Find("Canvas").transform;
                // bIntro = pf.Find("btt_introducao_aventura_1");
                // bIntro.SetSiblingIndex(16);

                break;

            case 1:
                pf2 = GameObject.Find("CanvasFase1").transform;
                bAve = pf2.Find("btt_aventurasolo_1");
                bIntro.SetSiblingIndex(6);
                bAve.SetSiblingIndex(16);
                destino = GameObject.Find("btt_aventurasolo_1");
                //ImageTutorial.DOAnchorPos(new Vector2(438, -16), 0.25f);
                break;
            case 2:
                
                pf2 = GameObject.Find("CanvasFase1").transform;
                bBack = pf2.Find("ButtonBack");
                bAve.SetSiblingIndex(7);
                bBack.SetSiblingIndex(16);
                destino = GameObject.Find("ButtonBack");
                //ImageTutorial.DOAnchorPos(new Vector2(88, -269), 0.25f);
                break;

        }

        spritesTutorial.sprite = sprites[verificadorIndexTutorial];

        //fade out
        if (verificadorIndexTutorial > 2)
        {
            StartCoroutine(FadeOut());
           
            bBack.SetSiblingIndex(14);

        }
    }

    public void NextTutorialCofre()
    {
        print(verificadorIndexTutorial);
        verificadorIndexTutorial++;


        switch (verificadorIndexTutorial)
        {
            case 0:
                destino = GameObject.Find("InputFieldAddCofre");
                //ImageTutorial.DOAnchorPos(new Vector2(112, -159), 0.25f);
                break;

            case 1:
                destino = GameObject.Find("btt_add_money");
                //ImageTutorial.DOAnchorPos(new Vector2(316, -174), 0.25f);
                break;
            case 2:
                destino = GameObject.Find("TextTotalCofrinho");
                //ImageTutorial.DOAnchorPos(new Vector2(401, -37), 0.25f);
                break;
            case 3:
                destino = GameObject.Find("btt_quebrar_cofre");
                //ImageTutorial.DOAnchorPos(new Vector2(446, -96), 0.25f);
                break;
            case 4:
                destino = GameObject.Find("ButtonBack");
                //ImageTutorial.DOAnchorPos(new Vector2(23, -215), 0.25f);
                break;
            case 5:
                destino = GameObject.Find("Background");
                ImageTutorial.transform.localScale = new Vector3(2.85f, 2f, 0f);
                //ImageTutorial.DOAnchorPos(new Vector2(23, -215), 0.25f);
                break;

        }

        spritesTutorial.sprite = sprites[verificadorIndexTutorial];

        //fade out
        if (verificadorIndexTutorial > 4)
        {
            
            StartCoroutine(FadeOut());
            ImageTutorial.transform.localScale = new Vector3(1f, 1f, 1f);

        }
    }

    public void NextTutorialConversor()
    {
        print(verificadorIndexTutorial);
        verificadorIndexTutorial++;


        switch (verificadorIndexTutorial)
        {
            case 0:
                destino = GameObject.Find("InputFieldMoeda");
                //ImageTutorial.DOAnchorPos(new Vector2(112, -159), 0.25f);
                break;

            case 1:
                destino = GameObject.Find("DropdownMoeda");
                //ImageTutorial.DOAnchorPos(new Vector2(402, -96), 0.25f);
                break;
            case 2:
                destino = GameObject.Find("TextInternet");
                //ImageTutorial.DOAnchorPos(new Vector2(384, -233), 0.25f);
                break;
            case 3:
                destino = GameObject.Find("btt_converter_currency");
                //ImageTutorial.DOAnchorPos(new Vector2(353, -180), 0.25f);
                break;
            case 4:
                destino = GameObject.Find("fundo_text_resultado");
                //ImageTutorial.DOAnchorPos(new Vector2(115, -101), 0.25f);
                break;
            case 5:
                destino = GameObject.Find("ButtonBack");
                //ImageTutorial.DOAnchorPos(new Vector2(23, -215), 0.25f);
                break;

        }

        spritesTutorial.sprite = sprites[verificadorIndexTutorial];

        //fade out
        if (verificadorIndexTutorial > 5)
        {
            StartCoroutine(FadeOut());
            
        }
    }

    public void NextTutorialIntroducao()
    {
        print(verificadorIndexTutorial);
        verificadorIndexTutorial++;


        switch (verificadorIndexTutorial)
        {
            case 0:
                destino = GameObject.Find("ButtonContinuar");
                //ImageTutorial.DOAnchorPos(new Vector2(613, -245), 0.25f);
                break;

            case 1:
                destino = GameObject.Find("ButtonContinuar");
               
                break;
           


        }

        spritesTutorial.sprite = sprites[verificadorIndexTutorial];

        //fade out
        if (verificadorIndexTutorial > 0)
        {
            StartCoroutine(FadeOut());
           // bVoltar.SetSiblingIndex(1);

        }
    }

    public void NextTutorialAventura()
    {
        print(verificadorIndexTutorial);
        verificadorIndexTutorial++;


        switch (verificadorIndexTutorial)
        {
            case 0:
                destino = GameObject.Find("PanelAventura");
                //ImageTutorial.transform.localScale = new Vector3(2.85f, 2f, 0f);
                ImageTutorial.sizeDelta = new Vector2(381, 198);

                //ImageTutorial.DOAnchorPos(new Vector2(638, -253), 0.25f);
                break;
            case 1:
                destino = GameObject.Find("BttContinuar");
                //ImageTutorial.DOAnchorPos(new Vector2(638, -253), 0.25f);
                break;
            case 2:
                destino = GameObject.Find("Btt_Perfil");
                //ImageTutorial.DOAnchorPos(new Vector2(670, 257), 0.25f);
                break;
            case 3:
                destino = GameObject.Find("Btt_Perfil");
                //ImageTutorial.DOAnchorPos(new Vector2(670, 257), 0.25f);
                break;
                /*
                case 2:
                    destino = GameObject.Find("ImageCenas");
                    //ImageTutorial.DOAnchorPos(new Vector2(0, 0), 0.25f);
                    break;
                case 3:
                    destino = GameObject.Find("ImageCenas");
                    //ImageTutorial.DOAnchorPos(new Vector2(0, 0), 0.25f);
                    break;
                */

        }

        spritesTutorial.sprite = sprites[verificadorIndexTutorial];

        //fade out
        if (verificadorIndexTutorial > 2)
        {
            StartCoroutine(FadeOut());
            
        }
    }
    public void FecharTutorial()
    {
        StartCoroutine(FadeOut());
        bMenu.SetSiblingIndex(2);
        bTuto.SetSiblingIndex(3);
        bConv.SetSiblingIndex(5);
        bCof.SetSiblingIndex(6);

        ImageTutorial.transform.localScale = new Vector3(1f, 1f, 1f);
        

    }

    public void Update()
    {
        if(movendo == true)
        {
            distancia = Vector3.Distance(transform.position, destino.transform.position);
            
            if (distanciaMinima <= distancia)
            {
                transform.position = Vector3.MoveTowards(transform.position, destino.transform.position, velocidade * Time.deltaTime);
                //bttNext.DOAnchorPos(new Vector2(destino.transform.position.x, destino.transform.position.y), 0.25f);
                //bttExit.DOAnchorPos(new Vector2(destino.transform.position.x + 77, destino.transform.position.y + 75), 0.25f);
                
                
            }
        }
    }

}
