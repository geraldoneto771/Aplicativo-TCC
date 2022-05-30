using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CanvasGroup loadingOverlay;
    [SerializeField]
    private float fadeTime = 0.5f;
    public GameObject textoCarregando;
    public static SceneLoader Instance { get; private set; }

    // função Awake é 
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

    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(PerformLoadSceneAsync(sceneName));
    }

    public void ApagarTexto()
    {
        textoCarregando.GetComponent<TMP_Text>().text = "";
    }
    public void AdicionarTexto()
    {
        textoCarregando.GetComponent<TMP_Text>().text = "Carregando...";

    }
    private IEnumerator PerformLoadSceneAsync(string sceneName)
    {
        //fade in
        yield return StartCoroutine(FadeIn());

        var operation = SceneManager.LoadSceneAsync(sceneName);
        //operation.progress
        while(operation.isDone == false)
        {
            yield return null;
        }

        //fade out
        yield return StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        float start = 0;
        float end = 1;
        float speed = (end - start) / fadeTime;

        loadingOverlay.alpha = start;

        while(loadingOverlay.alpha < end)
        {
            loadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }

        loadingOverlay.alpha = end;
    }
    private IEnumerator FadeOut()
    {
        float start = 1;
        float end = 0;
        float speed = (end - start) / fadeTime;

        loadingOverlay.alpha = start;

        while (loadingOverlay.alpha > end)
        {
            loadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }

        loadingOverlay.alpha = end;
    }


}
