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
    public Image spritesTutorial;
    public Sprite[] sprites;
    int index;
    public RectTransform ImageTutorial, bttNext;
    public CanvasGroup loadingOverlay2;
    public int sceneIndex = 0;
    public GameObject PanelTutorial;
    public Jogador jogador;

    //Movimentação do tutorial
    private GameObject destino;
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

        
    }


    public void LoadTutorialAsync()
    {
        StartCoroutine(FadeIn());
        
        sprites = Resources.LoadAll("TutorialTelaInicial", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = this.GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
        //ImageTutorial.DOAnchorPos(new Vector2(42, -52), 0.25f);
        destino = GameObject.Find("btt_menu");
    }

    public void LoadLoadTutorialFasesAsync()
    {
        StartCoroutine(FadeIn());
        
        sprites = Resources.LoadAll("TelaFases", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = this.GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
       // ImageTutorial.DOAnchorPos(new Vector2(88, -16), 0.25f);
        bttNext.DOAnchorPos(new Vector2(0, 70), 0.25f);
        destino = GameObject.Find("btt_introducao_aventura_1");
    }

    public void LoadLoadTutorialCofreAsync()
    {
        StartCoroutine(FadeIn());
        
        sprites = Resources.LoadAll("TelaCofre", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = this.GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
        //ImageTutorial.DOAnchorPos(new Vector2(112, -159), 0.25f);
        destino = GameObject.Find("InputFieldAddCofre");
        bttNext.DOAnchorPos(new Vector2(0, 30), 0.25f);
    }

    public void LoadLoadTutorialConversorAsync()
    {
        StartCoroutine(FadeIn());
        
        sprites = Resources.LoadAll("TelaConversor", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = this.GetComponent<Image>();
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
        spritesTutorial = this.GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
        //ImageTutorial.DOAnchorPos(new Vector2(613, -245), 0.25f);
        destino = GameObject.Find("ButtonContinuar");
        bttNext.DOAnchorPos(new Vector2(0, 51), 0.25f);
    }
    public void LoadLoadTutorialAventuraAsync()
    {
        StartCoroutine(FadeIn());
        
        sprites = Resources.LoadAll("TelaAventura", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = this.GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
        //ImageTutorial.DOAnchorPos(new Vector2(638, -253), 0.25f);
        destino = GameObject.Find("BttContinuar");
        bttNext.DOAnchorPos(new Vector2(0, 51), 0.25f);
    }

    private IEnumerator FadeIn()
    {
        
        float start = 0;
        float end = 1;
        float speed = (end - start) / fadeTime;

        loadingOverlay.alpha = start;
        loadingOverlay2.alpha = start;
        
        while (loadingOverlay.alpha < end)
        {
            loadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }

        loadingOverlay.alpha = end;
        loadingOverlay2.alpha = end;
        
    }
    private IEnumerator FadeOut()
    {
        float start = 1;
        float end = 0;
        float speed = (end - start) / fadeTime;

        loadingOverlay.alpha = start;
        loadingOverlay2.alpha = start;
        

        while (loadingOverlay.alpha > end)
        {
            loadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }

        loadingOverlay.alpha = end;
        loadingOverlay2.alpha = end;
       
    }

    public void NextTutorial()
    {
        print(verificadorIndexTutorial);
        verificadorIndexTutorial++;


        switch (verificadorIndexTutorial)
        {
            case 0:
                destino = GameObject.Find("btt_menu");
                //ImageTutorial.DOAnchorPos(new Vector2(42, -52), 0.25f);
                break;

            case 1:
                destino = GameObject.Find("btt_tutorial");
                //ImageTutorial.DOAnchorPos(new Vector2(562, -52), 0.25f);
                break;
            case 2:
                destino = GameObject.Find("btt_conversor");
                //ImageTutorial.DOAnchorPos(new Vector2(509, -211), 0.25f);
                break;
            case 3:
                destino = GameObject.Find("btt_cofre");
                //ImageTutorial.DOAnchorPos(new Vector2(566, -211), 0.25f);
                break;
            case 4:
                destino = GameObject.Find("btt_modulo_1");
                //ImageTutorial.DOAnchorPos(new Vector2(217, -74), 0.25f);
                break;
            case 5:
                destino = GameObject.Find("btt_next");
                //ImageTutorial.DOAnchorPos(new Vector2(529, -70), 0.25f);
                break;
            
        }

        spritesTutorial.sprite = sprites[verificadorIndexTutorial];

        //fade out
        if (verificadorIndexTutorial > 5)
        {
            StartCoroutine(FadeOut());
            
        }
    }

    public void NextTutorialFases()
    {
        print(verificadorIndexTutorial);
        verificadorIndexTutorial++;


        switch (verificadorIndexTutorial)
        {
            case 0:
                ImageTutorial.DOAnchorPos(new Vector2(88, -16), 0.25f);
                break;

            case 1:
                destino = GameObject.Find("btt_aventurasolo_1");
                //ImageTutorial.DOAnchorPos(new Vector2(438, -16), 0.25f);
                break;
            case 2:
                destino = GameObject.Find("ButtonBack");
                //ImageTutorial.DOAnchorPos(new Vector2(88, -269), 0.25f);
                break;

        }

        spritesTutorial.sprite = sprites[verificadorIndexTutorial];

        //fade out
        if (verificadorIndexTutorial > 2)
        {
            StartCoroutine(FadeOut());
            
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
        if (verificadorIndexTutorial > 5)
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
                //ImageTutorial.DOAnchorPos(new Vector2(613, -245), 0.25f);
                break;
            

        }

        spritesTutorial.sprite = sprites[verificadorIndexTutorial];

        //fade out
        if (verificadorIndexTutorial > 0)
        {
            StartCoroutine(FadeOut());
            
        }
    }

    public void NextTutorialAventura()
    {
        print(verificadorIndexTutorial);
        verificadorIndexTutorial++;


        switch (verificadorIndexTutorial)
        {
            case 0:
                destino = GameObject.Find("BttContinuar");
                //ImageTutorial.DOAnchorPos(new Vector2(638, -253), 0.25f);
                break;
            case 1:
                destino = GameObject.Find("Btt_Perfil");
                //ImageTutorial.DOAnchorPos(new Vector2(670, 257), 0.25f);
                break;
            case 2:
                destino = GameObject.Find("ImageCenas");
                //ImageTutorial.DOAnchorPos(new Vector2(0, 0), 0.25f);
                break;
            case 3:
                destino = GameObject.Find("ImageCenas");
                //ImageTutorial.DOAnchorPos(new Vector2(0, 0), 0.25f);
                break;


        }

        spritesTutorial.sprite = sprites[verificadorIndexTutorial];

        //fade out
        if (verificadorIndexTutorial > 2)
        {
            StartCoroutine(FadeOut());
            
        }
    }

    
   void Update()
    {
        if(movendo == true)
        {
            distancia = Vector3.Distance(transform.position, destino.transform.position);

            if(distanciaMinima <= distancia)
            {
                transform.position = Vector3.MoveTowards(transform.position, destino.transform.position, velocidade * Time.deltaTime);
            }
        }
    }

}
