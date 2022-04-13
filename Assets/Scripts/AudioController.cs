using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource backgroundMusic;
    public static AudioController instance = null;
    public AudioClip[] musicasDeFundo;
    // Start is called before the first frame update

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy (gameObject);

        DontDestroyOnLoad (gameObject);
    }

    void Start()
    {
        backgroundMusic.clip = musicasDeFundo[0];
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void PlayMusic(AudioClip clip)//We don't need Play for your problem.
    {
        backgroundMusic.clip = clip;
        backgroundMusic.Play ();
    }

    public void StopMusic(AudioClip clip)
    {
        backgroundMusic.clip = clip;
        backgroundMusic.Stop ();
    }
}

 
    

    

   