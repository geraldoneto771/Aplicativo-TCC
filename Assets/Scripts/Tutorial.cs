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
    public Jogador jogador;
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

        if(sceneIndex == 0 && jogador.tutorialTelaInicial == 0)
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
        ImageTutorial.DOAnchorPos(new Vector2(42, -52), 0.25f);
    }

    public void LoadLoadTutorialFasesAsync()
    {
        StartCoroutine(FadeIn());
        sprites = Resources.LoadAll("TelaFases", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = this.GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
        ImageTutorial.DOAnchorPos(new Vector2(11, -142), 0.25f);
        bttNext.DOAnchorPos(new Vector2(0, 70), 0.25f);
    }

    public void LoadLoadTutorialCofreAsync()
    {
        StartCoroutine(FadeIn());
        sprites = Resources.LoadAll("TelaCofre", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = this.GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
        ImageTutorial.DOAnchorPos(new Vector2(112, -159), 0.25f);
        bttNext.DOAnchorPos(new Vector2(0, 30), 0.25f);
    }

    public void LoadLoadTutorialConversorAsync()
    {
        StartCoroutine(FadeIn());
        sprites = Resources.LoadAll("TelaConversor", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = this.GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
        ImageTutorial.DOAnchorPos(new Vector2(102, -34), 0.25f);
        bttNext.DOAnchorPos(new Vector2(0, -29), 0.25f);
    }
    public void LoadLoadTutorialIntroducaoAsync()
    {
        StartCoroutine(FadeIn());
        sprites = Resources.LoadAll("TelaIntroducao", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = this.GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
        ImageTutorial.DOAnchorPos(new Vector2(468, -201), 0.25f);
        bttNext.DOAnchorPos(new Vector2(0, 30), 0.25f);
    }
    public void LoadLoadTutorialAventuraAsync()
    {
        StartCoroutine(FadeIn());
        sprites = Resources.LoadAll("TelaAventura", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = this.GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
        ImageTutorial.DOAnchorPos(new Vector2(452, -210), 0.25f);
        bttNext.DOAnchorPos(new Vector2(0, 30), 0.25f);
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
                ImageTutorial.DOAnchorPos(new Vector2(42, -52), 0.25f);
                break;

            case 1:
                ImageTutorial.DOAnchorPos(new Vector2(562, -52), 0.25f);
                break;
            case 2:
                ImageTutorial.DOAnchorPos(new Vector2(509, -211), 0.25f);
                break;
            case 3:
                ImageTutorial.DOAnchorPos(new Vector2(566, -211), 0.25f);
                break;
            case 4:
                ImageTutorial.DOAnchorPos(new Vector2(217, -74), 0.25f);
                break;
            case 5:
                ImageTutorial.DOAnchorPos(new Vector2(529, -70), 0.25f);
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
                ImageTutorial.DOAnchorPos(new Vector2(11, -142), 0.25f);
                break;

            case 1:
                ImageTutorial.DOAnchorPos(new Vector2(143, -142), 0.25f);
                break;
            case 2:
                ImageTutorial.DOAnchorPos(new Vector2(23, -215), 0.25f);
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
                ImageTutorial.DOAnchorPos(new Vector2(112, -159), 0.25f);
                break;

            case 1:
                ImageTutorial.DOAnchorPos(new Vector2(316, -174), 0.25f);
                break;
            case 2:
                ImageTutorial.DOAnchorPos(new Vector2(401, -37), 0.25f);
                break;
            case 3:
                ImageTutorial.DOAnchorPos(new Vector2(446, -96), 0.25f);
                break;
            case 4:
                ImageTutorial.DOAnchorPos(new Vector2(23, -215), 0.25f);
                break;

        }

        spritesTutorial.sprite = sprites[verificadorIndexTutorial];

        //fade out
        if (verificadorIndexTutorial > 4)
        {
            StartCoroutine(FadeOut());
        }
    }

    public void NextTutorialConversor()
    {
        print(verificadorIndexTutorial);
        verificadorIndexTutorial++;


        switch (verificadorIndexTutorial)
        {
            case 0:
                ImageTutorial.DOAnchorPos(new Vector2(112, -159), 0.25f);
                break;

            case 1:
                ImageTutorial.DOAnchorPos(new Vector2(402, -96), 0.25f);
                break;
            case 2:
                ImageTutorial.DOAnchorPos(new Vector2(384, -233), 0.25f);
                break;
            case 3:
                ImageTutorial.DOAnchorPos(new Vector2(353, -180), 0.25f);
                break;
            case 4:
                ImageTutorial.DOAnchorPos(new Vector2(115, -101), 0.25f);
                break;
            case 5:
                ImageTutorial.DOAnchorPos(new Vector2(23, -215), 0.25f);
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
                ImageTutorial.DOAnchorPos(new Vector2(468, -201), 0.25f);
                break;

            case 1:
                ImageTutorial.DOAnchorPos(new Vector2(468, -201), 0.25f);
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
                ImageTutorial.DOAnchorPos(new Vector2(452, -210), 0.25f);
                break;
            case 1:
                ImageTutorial.DOAnchorPos(new Vector2(472, -59), 0.25f);
                break;
            case 2:
                ImageTutorial.DOAnchorPos(new Vector2(263, -134), 0.25f);
                break;
            case 3:
                ImageTutorial.DOAnchorPos(new Vector2(263, -134), 0.25f);
                break;


        }

        spritesTutorial.sprite = sprites[verificadorIndexTutorial];

        //fade out
        if (verificadorIndexTutorial > 2)
        {
            StartCoroutine(FadeOut());
        }
    }
}
