// Verificar se esse arquivo ou o buttonControllNavigation está sendo usado para retornar telas

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class buttonBack : MonoBehaviour{
    
    
    public int sceneIndex = 0;
    private string nameScene;
    /*int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    */

    public void BackScene(){
        
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        print("Cena: "+ sceneIndex);
        
        if (sceneIndex >= 1 && sceneIndex <= 3)
        {
            Debug.Log("If 1");
            nameScene = "Tela_Inicial";
            SceneLoader.Instance.ApagarTexto();
            SceneLoader.Instance.LoadSceneAsync(nameScene);
            //SceneManager.LoadScene(0);
        }else if(sceneIndex > 3){
            Debug.Log("If 2");
            nameScene = "Tela_Modulo_1";
            SceneLoader.Instance.ApagarTexto();
            SceneLoader.Instance.LoadSceneAsync(nameScene);
            //SceneManager.LoadScene(1);
        }
        
    }
    
    // Update is called once per frame
 /*
    void Update(){
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        // print(SceneManager.GetActiveScene().buildIndex is int);
        // print(typeOf(SceneManager.GetActiveScene().buildIndex));

        if (Input.GetKeyDown(KeyCode.Escape)){
            if (sceneIndex > 3){
                SceneManager.LoadScene(1);
            }else if(sceneIndex > 0){
                SceneManager.LoadScene(0);
            }
        }


        // if (Input.GetKeyDown(KeyCode.Escape)){
        //     if (SceneManager.GetActiveScene().buildIndex == 0){
        //         Application.Quit();
        //     }else if (SceneManager.GetActiveScene().buildIndex > 3)
        //         SceneManager.LoadScene(0);
        //     else{
        //         SceneManager.LoadScene(1);
        //     }
        // }

        // if (Input.GetKeyDown(KeyCode.Escape)){
        //     if (SceneManager.GetActiveScene().buildIndex == 0){
        //         Application.Quit();
        //     }else if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        //         SceneManager.LoadScene(0);
        //     else{
        //         SceneManager.LoadScene(1);
        //     }
        // }
           
    }
 */
    
}
