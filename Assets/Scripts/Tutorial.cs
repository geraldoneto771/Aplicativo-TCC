using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using DG.Tweening;

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
    

    public void LoadTutorialAsync()
    {
        StartCoroutine(FadeIn());
        sprites = Resources.LoadAll("TutorialTelaInicial", typeof(Sprite)).Cast<Sprite>().ToArray();
        spritesTutorial = this.GetComponent<Image>();
        spritesTutorial.sprite = sprites[0];
        verificadorIndexTutorial = 0;
        ImageTutorial.DOAnchorPos(new Vector2(73, -18), 0.25f);
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
                ImageTutorial.DOAnchorPos(new Vector2(73, -18), 0.25f);
                break;

            case 1:
                ImageTutorial.DOAnchorPos(new Vector2(488, -18), 0.25f);
                break;
            case 2:
                ImageTutorial.DOAnchorPos(new Vector2(436, -259), 0.25f);
                break;
            case 3:
                ImageTutorial.DOAnchorPos(new Vector2(544, -212), 0.25f);
                break;
            case 4:
                ImageTutorial.DOAnchorPos(new Vector2(94, -45), 0.25f);
                break;
            case 5:
                ImageTutorial.DOAnchorPos(new Vector2(514, -85), 0.25f);
                break;
            
        }

        spritesTutorial.sprite = sprites[verificadorIndexTutorial];

        //fade out
        if (verificadorIndexTutorial > 5)
        {
            StartCoroutine(FadeOut());
        }
    }
}
